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

namespace ServiceProject3.Pages.Account.Materials.ManageSubCatePrices
{
    public class EditModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public EditModel(ServiceProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MaterialSubCatePrice MaterialSubCatePrice { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MaterialSubCatePrice = await _context.MaterialSubCatePrice
                .Include(m => m.Material)
                .Include(m => m.MaterialSubCategory).FirstOrDefaultAsync(m => m.Id == id);

            if (MaterialSubCatePrice == null)
            {
                return NotFound();
            }
           ViewData["MaterialId"] = new SelectList(_context.Material, "Id", "Id");
           ViewData["MaterialSubCategoryId"] = new SelectList(_context.MaterialSubCategory, "Id", "Id");
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

            _context.Attach(MaterialSubCatePrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialSubCatePriceExists(MaterialSubCatePrice.Id))
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

        private bool MaterialSubCatePriceExists(int id)
        {
            return _context.MaterialSubCatePrice.Any(e => e.Id == id);
        }
    }
}
