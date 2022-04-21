using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.Account.Rider
{
    public class DeliveredModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public DeliveredModel(ServiceProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MaterialBought MaterialBought { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MaterialBought = await _context.MaterialBought
                .Include(m => m.Material)
                .Include(m => m.Rider)
                .Include(m => m.Seeker).FirstOrDefaultAsync(m => m.Id == id);

            if (MaterialBought == null)
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

            MaterialBought = await _context.MaterialBought.FindAsync(id);

            if (MaterialBought != null)
            {
                MaterialBought.DeliveryStatus = true;
                _context.Attach(MaterialBought).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("././Index");
        }
    }
}
