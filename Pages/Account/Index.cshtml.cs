using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceProject3.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProject3.Pages.Account
{
    //[Authorize(Roles = "Provider")]
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public IndexModel(ServiceProject3.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Service> Service { get; set; }

        public IList<ServiceBought> PendngServices { get; set; }
        public IList<ServiceBought> ProviderProgress { get; set; }
        public IList<ServiceBought> ProviderCompleted { get; set; }



        public IList<Material> Materials { get; set; }
        public IList<MaterialBought> ProviderRequestedMaterials { get; set; }
        public IList<MaterialBought> ProviderTransitMaterials { get; set; }
        public IList<MaterialBought> ProviderDeliveredMaterials { get; set; }



        public IList<MaterialBought> ApprovedMaterialsSeeker { get; set; }
        public IList<MaterialBought> PendingMaterialsSeeker { get; set; }
        public IList<MaterialBought> CompletedMaterialsSeeker { get; set; }



        public IList<ServiceBought> ApprovedServicesSeeker { get; set; }
        public IList<ServiceBought> PendingServicesSeeker { get; set; }
        public IList<ServiceBought> CompletedServicesSeeker { get; set; }
        public async Task OnGetAsync()
        {
            Service = await _context.Service
                .Include(s => s.User).ToListAsync();
            var current_User = _userManager.GetUserAsync(HttpContext.User).Result;
            string current_User_Id = "" + current_User.Id;

            ProviderProgress = await _context.ServiceBought
                .Include(a => a.Service)
                .Include(b => b.Seeker)
                .Where(m => m.Service.UserId == current_User_Id && m.ApprovalStatus == true && m.CompletionStatus == false)
                .ToListAsync();

            ProviderCompleted = await _context.ServiceBought
                .Include(a => a.Service)
                .Include(b => b.Seeker)
                .Where(m => m.Service.UserId == current_User_Id && m.ApprovalStatus == true && m.CompletionStatus == true)
                .ToListAsync();

            PendngServices = await _context.ServiceBought
                .Include(a => a.Service)
                .Where(m => m.Service.UserId == current_User_Id && m.ApprovalStatus == false)
                .ToListAsync();

            Service = await _context.Service
                .Include(s => s.User)
                .Where(m => m.UserId == current_User_Id)
                .ToListAsync();


            PendingServicesSeeker = await _context.ServiceBought
                .Include(a => a.Service)
                .Where(m => m.SeekerId == current_User_Id && m.ApprovalStatus == false)
                .ToListAsync();
            ApprovedServicesSeeker = await _context.ServiceBought
                .Include(a => a.Service)
                .Where(m => m.SeekerId == current_User_Id && m.ApprovalStatus == true && m.CompletionStatus == false)
                .ToListAsync();
            CompletedServicesSeeker = await _context.ServiceBought
                .Include(a => a.Service)
                .Where(m => m.SeekerId == current_User_Id && m.ApprovalStatus == true && m.CompletionStatus == true)
                .ToListAsync();



            //Provider Materials

            Materials = await _context.Material
                .Include(s => s.User)
                .Where(m => m.UserId == current_User_Id)
                .ToListAsync();

            ProviderRequestedMaterials = await _context.MaterialBought
                .Include(s => s.Material)
                .Where(m => m.Material.UserId == current_User_Id && m.ApprovalStatus == false)
                .ToListAsync();

            ProviderTransitMaterials = await _context.MaterialBought
                .Include(s => s.Material)
                .Where(m => m.Material.UserId == current_User_Id && m.ApprovalStatus == true && m.DeliveryStatus == false)
                .ToListAsync();

            ProviderDeliveredMaterials = await _context.MaterialBought
               .Include(a => a.Material)
               .Include(b => b.Seeker)
               .Where(m => m.Material.UserId == current_User_Id && m.ApprovalStatus == true && m.DeliveryStatus == true)
               .ToListAsync();



            //Seeker Materials

            ApprovedMaterialsSeeker = await _context.MaterialBought
                .Include(a => a.Material)
                .Where(m => m.SeekerId == current_User_Id && m.ApprovalStatus == true && m.DeliveryStatus == false)
                .ToListAsync();

            PendingMaterialsSeeker = await _context.MaterialBought
                .Include(a => a.Material)
                .Where(m => m.SeekerId == current_User_Id && m.ApprovalStatus == false)
                .ToListAsync();

            CompletedMaterialsSeeker = await _context.MaterialBought
                .Include(a => a.Material)
                .Where(m => m.SeekerId == current_User_Id && m.ApprovalStatus == true && m.DeliveryStatus == true)
                .ToListAsync();

        }
    }
}
