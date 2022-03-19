using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.Account.Services
{
    [Authorize(Roles ="Provider")]
    public class IndexModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public IndexModel(ServiceProject3.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Service> Service { get;set; }

        public async Task OnGetAsync()
        {
            Service = await _context.Service
                .Include(s => s.User).ToListAsync();
            var current_User = _userManager.GetUserAsync(HttpContext.User).Result;
            string current_User_Id = "" + current_User.Id;
            Service = await _context.Service
                .Include(s => s.User).Where(m => m.UserId == current_User_Id).ToListAsync();
        }
    }
}
