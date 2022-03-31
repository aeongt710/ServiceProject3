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
            return Page();
        }

        [BindProperty]
        public MaterialBought MaterialBought { get; set; }

        int mid;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var current_User = _userManager.GetUserAsync(HttpContext.User).Result;
            string current_User_Id = "" + current_User.Id;
            MaterialBought.SeekerId = current_User_Id;
            MaterialBought.ApprovalStatus = false;
            MaterialBought.DeliveryStatus = false;
            MaterialBought.Rating = -1;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MaterialBought.Add(MaterialBought);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
