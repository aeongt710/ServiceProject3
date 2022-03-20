using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.Account.PendingServices
{
    [Authorize(Roles = "Provider")]
    public class IndexModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public IndexModel(ServiceProject3.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<ServiceBought> ServiceBought { get;set; }

        public async Task OnGetAsync()
        {
            //ServiceBought = await _context.ServiceBought
            //    .Include(s => s.Seeker)
            //    .Include(s => s.Service).ToListAsync();

            var current_User = _userManager.GetUserAsync(HttpContext.User).Result;
            string current_User_Id = "" + current_User.Id;
            ServiceBought = await _context.ServiceBought
                .Include(a => a.Service)
                .Where(m => m.Service.UserId == current_User_Id && m.ApprovalStatus == false).ToListAsync();
        }
    }
}
