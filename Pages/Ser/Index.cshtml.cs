using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.Ser
{
    public class IndexModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public IndexModel(ServiceProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; }

        public async Task OnGetAsync()
        {
            Service = await _context.Service
                .Include(s => s.Category)
                .Include(s => s.User).ToListAsync();
        }
    }
}
