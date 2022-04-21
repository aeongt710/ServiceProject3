using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.Account.Rider
{
    public class InTransitModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public InTransitModel(ServiceProject3.Data.ApplicationDbContext context,UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<MaterialBought> MaterialBought { get;set; }

        public async Task OnGetAsync()
        {
            var current_User = _userManager.GetUserAsync(HttpContext.User).Result;
            string current_User_Id = "" + current_User.Id;
            MaterialBought = await _context.MaterialBought
                .Include(a => a.Material)
                .Include(s => s.Seeker)
                .Where(m => m.RiderId == current_User_Id && m.ApprovalStatus == true && m.PickUp == true && m.DeliveryStatus == false)
                .ToListAsync();
        }
    }
}
