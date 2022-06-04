using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.Account.Materials.ManageSubCatePrices
{
    public class IndexModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public IndexModel(ServiceProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MaterialSubCatePrice> MaterialSubCatePrice { get;set; }

        public async Task OnGetAsync()
        {
            MaterialSubCatePrice = await _context.MaterialSubCatePrice
                .Include(m => m.Material)
                .Include(m => m.MaterialSubCategory).ToListAsync();
        }
    }
}
