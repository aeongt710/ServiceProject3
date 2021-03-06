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

namespace ServiceProject3.Pages.Materials
{
    public class BuyModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public BuyModel(ServiceProject3.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet(string id)
        {
            MaterialBought = new MaterialBought();
            MaterialBought.MaterialId = Int32.Parse(id);
            mid = Int32.Parse(id);
            ViewData["SeekerId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["MaterialId"] = new SelectList(_context.Material, "Id", "Id");


            MaterialForCate = _context.Material.FirstOrDefault(a=>a.Id == mid);
            MaterialBought.TotalPrice = MaterialForCate.Price;
            MaterialBought.Quantity = 1;
            MaterialBought.Material = _context.Material.FirstOrDefault(a => a.Id == MaterialBought.MaterialId);
            UnitPrice = MaterialForCate.Price;
            SubCats = _context.MaterialSubCategory.Where(b=>b.MaterialCategoryId== MaterialForCate.MaterialCategoryId).ToList();


            subCatePrices = _context.MaterialSubCatePrice
                .Where(a=> a.MaterialId == MaterialBought.MaterialId)
                .ToList();

            return Page();
        }

        [BindProperty]
        public IList<MaterialSubCatePrice> subCatePrices { get; set; }

        [BindProperty]
        public int UnitPrice { get; set; }
        [BindProperty]
        public Material MaterialForCate { get; set; }

        [BindProperty]
        public IList<MaterialSubCategory> SubCats { get; set; }
        [BindProperty]
        public MaterialBought MaterialBought { get; set; }

        int mid;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            MaterialBought.SubCategory=_context.MaterialSubCategory.Where(a=>a.Id==Int32.Parse(MaterialBought.SubCategory)).FirstOrDefault().Name;
            var current_User = _userManager.GetUserAsync(HttpContext.User).Result;
            string current_User_Id = "" + current_User.Id;
            MaterialBought.SeekerId = current_User_Id;
            MaterialBought.ApprovalStatus = false;
            MaterialBought.DeliveryStatus = false;
            MaterialBought.Rating = -1;
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.MaterialBought.Add(MaterialBought);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
