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
    public class IndexModel : PageModel
    {
        private readonly VisitorDetails.Data.ApplicationDbContext _context;

        public IndexModel(VisitorDetails.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Visitor> Visitor { get;set; }

        public async Task OnGetAsync()
        {
            Visitor = await _context.Visitor.ToListAsync();
        }
    }
}
