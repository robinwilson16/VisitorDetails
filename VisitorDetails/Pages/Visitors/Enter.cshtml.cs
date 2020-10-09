using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VisitorDetails.Data;
using VisitorDetails.Models;

namespace VisitorDetails.Pages.Visitors
{
    public class EnterModel : PageModel
    {
        private readonly VisitorDetails.Data.ApplicationDbContext _context;
        private IHttpContextAccessor _accessor;

        public EnterModel(
            VisitorDetails.Data.ApplicationDbContext context,
            IHttpContextAccessor accessor
            )
        {
            _context = context;
            _accessor = accessor;
        }

        public async Task<IActionResult> OnGetAsync(string site)
        {
            FormSubmitted = false;

            PurposeOfVisit = await _context.PurposeOfVisit
                .OrderBy(r => r.SortOrder)
                .ThenBy(r => r.Name)
                .Select(
                    r => new SelectListItem
                    {
                        Value = r.PurposeOfVisitID.ToString(),
                        Text = r.Name
                    }
                )
                .AsNoTracking()
                .ToListAsync();

            Site = (await _context.Site
                .FromSqlInterpolated($"EXEC SPR_VIS_SiteDetails @Site={site}")
                .ToListAsync())
                .FirstOrDefault();

            if (Site == null)
            {
                SiteIsValid = false;
                SiteName = "Unknown";
            }
            else
            {
                SiteIsValid = true;
                SiteName = Site.SiteName;
            }

            if (SiteIsValid == true)
            {
                Visitor = new Visitor
                {
                    SiteCode = Site.SiteCode,
                    CreatedDate = DateTime.Now,
                    IPAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString()
                };
            }
            else
            {
                Visitor = new Visitor
                {
                    CreatedDate = DateTime.Now,
                    IPAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString()
                };
            }

            return Page();
        }

        [BindProperty]
        public Visitor Visitor { get; set; }
        public Site Site { get; set; }
        public IList<SelectListItem> PurposeOfVisit { get; set; }
        public bool SiteIsValid { get; set; }

        public string SiteName { get; set; }
        public bool FormSubmitted { get; set; }
        public bool FormSaved { get; set; }

        public string FormErrors { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string site)
        {
            FormSubmitted = true;
            FormSaved = true;
            string FormErrors = null;

            Site = (await _context.Site
                .FromSqlInterpolated($"EXEC SPR_VIS_SiteDetails @Site={site}")
                .ToListAsync())
                .FirstOrDefault();

            if (Site == null)
            {
                SiteIsValid = false;
                SiteName = "Unknown";
            }
            else
            {
                SiteIsValid = true;
                SiteName = Site.SiteName;
            }

            Visitor.SiteCode = Site.SiteCode;
            Visitor.CreatedDate = DateTime.Now;
            Visitor.IPAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            Visitor.UserAgent = _accessor.HttpContext.Request.Headers["User-Agent"];

            ModelState.Remove("Visitor.SiteCode");

            if (!ModelState.IsValid)
            {
                FormSaved = false;
                FormErrors = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            }

            _context.Visitor.Add(Visitor);
            await _context.SaveChangesAsync();

            int userID = Visitor.VisitorID;
            //Store Cookie to track user ID - valid for 12 hours
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddHours(12);
            option.IsEssential = true;
            option.Secure = true;
            option.HttpOnly = true;
            option.SameSite = SameSiteMode.Strict;
            _accessor.HttpContext.Response.Cookies.Append("UserID", userID.ToString(), option);

            //return RedirectToPage("./Index");
            return Page();
        }
    }
}
