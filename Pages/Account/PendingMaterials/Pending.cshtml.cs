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

namespace ServiceProject3.Pages.Account.PendingMaterials
{
    public class PendingModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public PendingModel(ServiceProject3.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<ServiceBought> ServiceBought { get; set; }

        public async Task OnGetAsync()
        {
            //ServiceBought = await _context.ServiceBought
            //    .Include(s => s.Seeker)
            //    .Include(s => s.Service).ToListAsync();

            var current_User = _userManager.GetUserAsync(HttpContext.User).Result;
            string current_User_Id = "" + current_User.Id;
            ServiceBought = await _context.ServiceBought
                .Include(a => a.Service)
                .Include(b => b.Seeker)
                .Where(m => m.Service.UserId == current_User_Id && m.ApprovalStatus == true && m.CompletionStatus==false).ToListAsync();
        }
    }
}
