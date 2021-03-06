using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.Services
{
    public class DetailsModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public DetailsModel(ServiceProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Service Service { get; set; }
        public IList<ServiceBought> ServiceBought { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Service = await _context.Service
                .Include(s => s.User).FirstOrDefaultAsync(m => m.Id == id);
            ServiceBought = await _context.ServiceBought
                .Include(a => a.Service)
                .Include(b => b.Seeker)
                .Where(m => m.ServiceId  == id).ToListAsync();
            if (Service == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
