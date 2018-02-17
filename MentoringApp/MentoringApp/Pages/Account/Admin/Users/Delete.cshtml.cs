using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentoringApp.Data;
using MentoringApp.Models;

namespace MentoringApp.Pages.Account.Admin.Users
{
    public class DeleteModel : PageModel
    {
        private readonly UserManager<MentoringApp.Data.ApplicationUser> userManager;
        private readonly RoleManager<MentoringApp.Data.ApplicationRole> roleManager;

        public DeleteModel(UserManager<MentoringApp.Data.ApplicationUser> um, RoleManager<MentoringApp.Data.ApplicationRole> rm)
        {
            userManager = um;
            roleManager = rm;
        }

        [BindProperty]
        public UserEdit MyUser { get; set; }

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
            else if (!applicationUser.Editable)
            {
                return RedirectToPage("/Account/AccessDenied");
            }

            var role = (await userManager.GetRolesAsync(applicationUser)).SingleOrDefault();
            string roleID = null;
            if (!String.IsNullOrEmpty(role))
            {
                roleID = roleManager.Roles.SingleOrDefault(r => r.Name == role).Id;
            }

            MyUser = new Models.UserEdit
            {
                Id = applicationUser.Id,
                Name = applicationUser.Name,
                UserName = applicationUser.UserName,
                Email = applicationUser.Email,
                Editable = applicationUser.Editable,
                Role = await roleManager.Roles.Select(r => new Role
                {
                    Id = r.Id,
                    RoleName = r.Name,
                    Description = r.Description
                }).SingleOrDefaultAsync(m => m.Id == roleID)
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            ApplicationUser applicationUser = await userManager.FindByIdAsync(id);

            if (applicationUser != null && applicationUser.Editable)
            {
                await userManager.DeleteAsync(applicationUser);
            }

            return RedirectToPage("./Index");
        }
    }
}
