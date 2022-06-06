using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.Account.Materials
{
    public class DeleteModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public DeleteModel(ServiceProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Material Material { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Material = await _context.Material
                .Include(m => m.User).FirstOrDefaultAsync(m => m.Id == id);

            if (Material == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Material = await _context.Material.FindAsync(id);

            if (Material != null)
            {
                IList<MaterialSubCatePrice> list = _context.MaterialSubCatePrice.Where(a => a.MaterialId == Material.Id).ToList();
                //foreach (var item in list)
                    _context.RemoveRange(list);
                await _context.SaveChangesAsync();
                _context.Material.Remove(Material);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
