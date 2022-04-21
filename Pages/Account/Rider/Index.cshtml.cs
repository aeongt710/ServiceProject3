using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.Account.Rider
{
    public class IndexModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public IndexModel(ServiceProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MaterialBought> MaterialBought { get;set; }

        public async Task OnGetAsync()
        {
            MaterialBought = await _context.MaterialBought
                .Include(a => a.Material)
                .Include(s => s.Seeker)
                .Where(m => m.RiderId == null && m.ApprovalStatus == true && m.PickUp == false)
                .ToListAsync();
        }
    }
}
