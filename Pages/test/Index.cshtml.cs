using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.test
{
    public class IndexModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public IndexModel(ServiceProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ServiceBought> ServiceBought { get;set; }

        public async Task OnGetAsync()
        {
            ServiceBought = await _context.ServiceBought
                .Include(s => s.Seeker)
                .Include(s => s.Service).ToListAsync();
        }
    }
}
