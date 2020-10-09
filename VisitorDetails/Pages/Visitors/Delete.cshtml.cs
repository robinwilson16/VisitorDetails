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
    public class DeleteModel : PageModel
    {
        private readonly VisitorDetails.Data.ApplicationDbContext _context;

        public DeleteModel(VisitorDetails.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Visitor = await _context.Visitor.FindAsync(id);

            if (Visitor != null)
            {
                _context.Visitor.Remove(Visitor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
