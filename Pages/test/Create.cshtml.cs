using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.test
{
    public class CreateModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public CreateModel(ServiceProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SeekerId"] = new SelectList(_context.Users, "Id", "Id");
        ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ServiceBought ServiceBought { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ServiceBought.Add(ServiceBought);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
