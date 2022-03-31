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

namespace ServiceProject3.Pages.Account.Seeker.Materials
{
    public class CompletedModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public CompletedModel(ServiceProject3.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
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
                .Include(b => b.Seeker)
                .Where(m => m.SeekerId == current_User_Id && m.DeliveryStatus == true && m.ApprovalStatus==true).ToListAsync();
        }
    }
}
