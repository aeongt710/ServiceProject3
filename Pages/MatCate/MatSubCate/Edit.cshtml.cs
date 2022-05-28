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

namespace ServiceProject3.Pages.MatCate.MatSubCate
{
    public class EditModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public EditModel(ServiceProject3.Data.ApplicationDbContext context)
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
           ViewData["MaterialCategoryId"] = new SelectList(_context.MaterialCategory, "Id", "Id");
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

            _context.Attach(MaterialSubCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialSubCategoryExists(MaterialSubCategory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index",new {id = MaterialSubCategory.MaterialCategoryId });
        }

        private bool MaterialSubCategoryExists(int id)
        {
            return _context.MaterialSubCategory.Any(e => e.Id == id);
        }
    }
}
