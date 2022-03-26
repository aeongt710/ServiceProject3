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

namespace ServiceProject3.Pages.Account.Seeker.Services
{
    public class CompleteModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public CompleteModel(ServiceProject3.Data.ApplicationDbContext context)
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
           ViewData["SeekerId"] = new SelectList(_context.Users, "Id", "Id");
           ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Id");
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
            ServiceBought.CompletionStatus = true;
            _context.Attach(ServiceBought).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceBoughtExists(ServiceBought.Id))
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
