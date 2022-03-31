using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceProject3.Data;
using ServiceProject3.Models;

namespace ServiceProject3.Pages.Account.PendingMaterials
{
    [Authorize(Roles = "Provider")]
    public class ApproveModel : PageModel
    {
        private readonly ServiceProject3.Data.ApplicationDbContext _context;

        public ApproveModel(ServiceProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MaterialBought MaterialBought { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MaterialBought = await _context.MaterialBought
                .Include(s => s.Seeker)
                .Include(s => s.Material).FirstOrDefaultAsync(m => m.Id == id);

            if (MaterialBought == null)
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

            MaterialBought = await _context.MaterialBought.FindAsync(id);

            if (MaterialBought != null)
            {
                MaterialBought.ApprovalStatus = true;
                _context.Attach(MaterialBought).State = EntityState.Modified;
                //_context.ServiceBought.Remove(ServiceBought);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}