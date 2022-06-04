using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.Account.Materials
{
    public class CreateModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public CreateModel(ServiceProject3.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            SubCats = _context.MaterialSubCategory.ToList();
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["MaterialCategoryId"] = new SelectList(_context.MaterialCategory, "Id", "Name");
            var current_User = _userManager.GetUserAsync(HttpContext.User).Result;
            UserId = "" + current_User.Id;
            return Page();
        }
        [BindProperty]
        public string UserId { get; set; }

        [BindProperty]
        public Material Material { get; set; }
        [BindProperty]
        public IList<MaterialSubCategory> SubCats { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var current_User = _userManager.GetUserAsync(HttpContext.User).Result;
            Material.UserId = "" + current_User.Id;
            _context.Material.Add(Material);
            await _context.SaveChangesAsync();

            IList<MaterialSubCategory> subCategories = _context.MaterialSubCategory
                .Where(a => a.MaterialCategoryId == Material.MaterialCategoryId).ToList();

            foreach (var item in subCategories)
            {
                _context.Add(new MaterialSubCatePrice()
                {
                    MaterialId = Material.Id,
                    MaterialSubCategoryId=item.Id,
                    Price = 0
                });
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
