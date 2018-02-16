using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MentoringApp.Models;

namespace MentoringApp.Pages.Account.Admin.Roles
{
    public class IndexModel : PageModel
    {
        private readonly RoleManager<MentoringApp.Data.ApplicationRole> roleManager;

        public IndexModel(RoleManager<MentoringApp.Data.ApplicationRole> rm)
        {
            roleManager = rm;
        }

        public IList<Role> Roles { get; set; }

        public async Task OnGetAsync()
        {
            Roles = await roleManager.Roles.Select(r => new Role
            {
                Id = r.Id,
                RoleName = r.Name,
                Description = r.Description,
                Editable = r.Editable
            }).ToListAsync();
        }
    }
}