using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VisitorDetails.Data;
using VisitorDetails.Models;

namespace VisitorDetails.Pages.Visitors
{
    public class DetailsModel : PageModel
    {
        private readonly VisitorDetails.Data.ApplicationDbContext _context;

        public DetailsModel(VisitorDetails.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Visitor Visitor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Visitor = await _context.Visitor.FirstOrDefaultAsync(m => m.VisitorID == id);

            if (Visitor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
