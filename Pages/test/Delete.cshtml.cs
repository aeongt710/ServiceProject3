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
    public class DeleteModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public DeleteModel(ServiceProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ServiceBought ServiceBought { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServiceBought = await _context.ServiceBought
                .Include(s => s.Seeker)
                .Include(s => s.Service).FirstOrDefaultAsync(m => m.Id == id);

            if (ServiceBought == null)
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

            ServiceBought = await _context.ServiceBought.FindAsync(id);

            if (ServiceBought != null)
            {
                _context.ServiceBought.Remove(ServiceBought);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
