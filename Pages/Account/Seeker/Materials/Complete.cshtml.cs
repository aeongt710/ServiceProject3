using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.Account.Seeker.Materials
{
    public class CompleteModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public CompleteModel(ServiceProject3.Data.ApplicationDbContext context)
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
                .Include(s => s.Seeker)
                .Include(s => s.Material).FirstOrDefaultAsync(m => m.Id == id);

            if (MaterialBought == null)
            {
                return NotFound();
            }
           ViewData["SeekerId"] = new SelectList(_context.Users, "Id", "Id");
           ViewData["MaterialId"] = new SelectList(_context.Material, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            MaterialBought.DeliveryStatus = true;
            _context.Attach(MaterialBought).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceBoughtExists(MaterialBought.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ServiceBoughtExists(int id)
        {
            return _context.ServiceBought.Any(e => e.Id == id);
        }
    }
}
