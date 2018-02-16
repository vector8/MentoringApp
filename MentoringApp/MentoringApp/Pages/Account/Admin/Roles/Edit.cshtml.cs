using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentoringApp.Data;
using MentoringApp.Models;

namespace MentoringApp.Pages.Account.Admin.Roles
{
    public class EditModel : PageModel
    {
        private readonly RoleManager<MentoringApp.Data.ApplicationRole> roleManager;

        public EditModel(RoleManager<MentoringApp.Data.ApplicationRole> rm)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ApplicationRole appRole = await roleManager.FindByIdAsync(Role.Id);

            if(!appRole.Editable)
            {
                return Page();
            }

            appRole.Name = Role.RoleName;
            appRole.Description = Role.Description;

            try
            {
                await roleManager.UpdateAsync(appRole);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await RoleExists(Role.RoleName))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> RoleExists(string name)
        {
            return await roleManager.RoleExistsAsync(name);
        }
    }
}
