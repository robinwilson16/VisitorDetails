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
    public class LeaveModel : PageModel
    {
        private readonly VisitorDetails.Data.ApplicationDbContext _context;
        private IHttpContextAccessor _accessor;

        public LeaveModel(
            VisitorDetails.Data.ApplicationDbContext context,
            IHttpContextAccessor accessor
            )
        {
            _context = context;
            _accessor = accessor;
        }

        public async Task<IActionResult> OnGetAsync(string site)
        {
            string ipAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            string userAgent = _accessor.HttpContext.Request.Headers["User-Agent"];

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

            int userID;
            int.TryParse(Request.Cookies["UserID"], out userID);

            //Cookie is valid
            if(userID > 0)
            {
                UserIDNotNull = true;
                UserIdentificationMethod = "Cookie";
            }
            else
            {
                UserIDNotNull = false;
            }

            //If cookie valid
            if(UserIDNotNull == true)
            {
                Visitor = _context.Visitor
                .Where(x => x.VisitorID == userID)
                .FirstOrDefault();

                //User found
                if(Visitor.VisitorID > 0)
                {
                    UserIDValid = true;
                    Visitor.LeaveDate = DateTime.Now;
                    await _context.SaveChangesAsync();
                    Response.Cookies.Delete("UserID");
                }
                else
                {
                    UserIDValid = false;
                }
            }
            else //If user was invalid try searching database for record instead
            {
                Visitor = (await _context.Visitor
                    .FromSqlInterpolated($"EXEC SPR_VIS_GetUserByIP @IPAddress={ipAddress}, @UserAgent={userAgent}, @Site={site}")
                    .ToListAsync())
                    .FirstOrDefault();

                if (Visitor != null)
                {
                    if (Visitor.VisitorID > 0)
                    {
                        UserIDValid = true;
                        userID = Visitor.VisitorID;
                        Visitor.LeaveDate = DateTime.Now;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        UserIDValid = false;
                    }

                    //Single record was found
                    if (userID > 0)
                    {
                        UserIDNotNull = true;
                        UserIdentificationMethod = "Database";
                    }
                    else
                    {
                        UserIDNotNull = false;
                    }
                }
                else
                {
                    UserIDValid = false;
                }
            }

            return Page();
        }

        [BindProperty]
        public Visitor Visitor { get; set; }
        public Site Site { get; set; }
        public bool SiteIsValid { get; set; }

        public string SiteName { get; set; }
        public bool UserIDNotNull { get; set; }
        public bool UserIDValid { get; set; }
        public string UserIdentificationMethod { get; set; }
    }
}
