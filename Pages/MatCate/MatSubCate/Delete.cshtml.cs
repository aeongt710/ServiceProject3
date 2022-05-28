using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.MatCate.MatSubCate
{
    public class DeleteModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public DeleteModel(ServiceProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MaterialSubCategory MaterialSubCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MaterialSubCategory = await _context.MaterialSubCategory
                .Include(m => m.MaterialCategory).FirstOrDefaultAsync(m => m.Id == id);

            if (MaterialSubCategory == null)
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

            MaterialSubCategory = await _context.MaterialSubCategory.FindAsync(id);

            if (MaterialSubCategory != null)
            {
                _context.MaterialSubCategory.Remove(MaterialSubCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { id = MaterialSubCategory.MaterialCategoryId });
        }
    }
}
