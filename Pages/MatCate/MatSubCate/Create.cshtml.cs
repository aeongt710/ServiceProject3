using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.MatCate.MatSubCate
{
    public class CreateModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public CreateModel(ServiceProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public int Id { get; set; }
        public IActionResult OnGet(int id)
        {
            Id = id;
            ViewData["MaterialCategoryId"] = new SelectList(_context.MaterialCategory, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public MaterialSubCategory MaterialSubCategory { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            MaterialSubCategory.MaterialCategoryId = Id;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MaterialSubCategory.Add(MaterialSubCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index",new { id= Id});
        }
    }
}
