using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.Account.Materials.ManageSubCatePrices
{
    public class DeleteModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public DeleteModel(ServiceProject3.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MaterialSubCatePrice = await _context.MaterialSubCatePrice.FindAsync(id);

            if (MaterialSubCatePrice != null)
            {
                _context.MaterialSubCatePrice.Remove(MaterialSubCatePrice);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { Id = MaterialSubCatePrice.MaterialId });
        }
    }
}
