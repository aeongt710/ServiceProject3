using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.MatCate.MatSubCate
{
    public class IndexModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public IndexModel(ServiceProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MaterialSubCategory> MaterialSubCategory { get;set; }
        [BindProperty]
        public int Id { get; set; }

        public async Task OnGetAsync(int id)
        {
            if (id == 0)
                Response.Redirect("././Index"); 
            Id = id;
            MaterialSubCategory = await _context.MaterialSubCategory
                .Include(m => m.MaterialCategory).Where(a=>a.MaterialCategoryId==id).ToListAsync();
        }
    }
}
