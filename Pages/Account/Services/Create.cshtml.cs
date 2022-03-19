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

namespace ServiceProject3.Pages.Account.Services
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");

            var current_User = _userManager.GetUserAsync(HttpContext.User).Result;
            UserId = "" + current_User.Id;
            //Service.UserId = UserId;
            return Page();
        }
        [BindProperty]
        public string UserId { get; set; }

        [BindProperty]
        public Service Service { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var current_User = _userManager.GetUserAsync(HttpContext.User).Result;
            Service.UserId = "" + current_User.Id;
            //Service.UserId = UserId;
            _context.Service.Add(Service);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
