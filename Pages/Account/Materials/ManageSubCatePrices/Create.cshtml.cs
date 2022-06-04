using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.Account.Materials.ManageSubCatePrices
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
        ViewData["MaterialId"] = new SelectList(_context.Material, "Id", "Id");
        ViewData["MaterialSubCategoryId"] = new SelectList(_context.MaterialSubCategory, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public MaterialSubCatePrice MaterialSubCatePrice { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MaterialSubCatePrice.Add(MaterialSubCatePrice);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
