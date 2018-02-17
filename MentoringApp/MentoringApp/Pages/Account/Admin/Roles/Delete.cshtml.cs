using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MentoringApp.Data;
using MentoringApp.Models;

namespace MentoringApp.Pages.Account.Admin.Roles
{
    public class DeleteModel : PageModel
    {
        private readonly RoleManager<MentoringApp.Data.ApplicationRole> roleManager;

        public DeleteModel(RoleManager<MentoringApp.Data.ApplicationRole> rm)
        {
            roleManager = rm;
        }

        [BindProperty]
        public Role Role { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            Role = await roleManager.Roles.Select(r => new Role
            {
                Id = r.Id,
                RoleName = r.Name,
                Description = r.Description
            }).SingleOrDefaultAsync(m => m.Id == id);

            if (Role == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            ApplicationRole appRole = await roleManager.FindByIdAsync(id);

            if (appRole != null && appRole.Editable)
            {
                await roleManager.DeleteAsync(appRole);
            }

            return RedirectToPage("./Index");
        }
    }
}
