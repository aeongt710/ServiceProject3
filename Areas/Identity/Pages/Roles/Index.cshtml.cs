using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ServiceProject3.Areas.Identity.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private RoleManager<IdentityRole> _roleManager;
        public IndexModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IList<IdentityRole> AllRoles;
        public void OnGet()
        {
            AllRoles = _roleManager.Roles.ToList();

        }
    }
}
