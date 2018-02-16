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

namespace MentoringApp.Pages.Account.Admin.Users
{
    public class EditModel : PageModel
    {
        private readonly UserManager<MentoringApp.Data.ApplicationUser> userManager;
        private readonly RoleManager<MentoringApp.Data.ApplicationRole> roleManager;

        public EditModel(UserManager<MentoringApp.Data.ApplicationUser> um, RoleManager<MentoringApp.Data.ApplicationRole> rm)
        {
            userManager = um;
            roleManager = rm;
        }

        [BindProperty]
        public User MyUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            Data.ApplicationUser applicationUser = await userManager.FindByIdAsync(id);

            if (applicationUser == null)
            {
                return NotFound();
            }
            else if(!applicationUser.Editable)
            {
                return RedirectToPage("/Account/AccessDenied");
            }

            string role = userManager.GetRolesAsync(applicationUser).Result.Single();

            MyUser = new User
            {
                Id = applicationUser.Id,
                Name = applicationUser.Name,
                UserName = applicationUser.Name,
                Email = applicationUser.Email,
                Editable = applicationUser.Editable,
                Role = await roleManager.Roles.Select(r => new Role
                {
                    Id = r.Id,
                    RoleName = r.Name,
                    Description = r.Description
                }).SingleOrDefaultAsync(m => m.RoleName == role)
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ApplicationUser applicationUser = await userManager.FindByIdAsync(MyUser.Id);

            if(!applicationUser.Editable)
            {
                return Page();
            }

            //appRole.Name = Role.RoleName;
            //appRole.Description = Role.Description;

            //try
            //{
            //    await roleManager.UpdateAsync(appRole);
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (! await RoleExists(Role.RoleName))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("./Index");
        }

        private async Task<bool> RoleExists(string name)
        {
            return await roleManager.RoleExistsAsync(name);
        }
    }
}
