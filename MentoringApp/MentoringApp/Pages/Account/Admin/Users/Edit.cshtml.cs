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
        public UserEdit MyUser { get; set; }

        public List<SelectListItem> Roles { get; set; }

        [BindProperty]
        public string RoleID { get; set; }

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

            Roles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();

            var role = (await userManager.GetRolesAsync(applicationUser)).SingleOrDefault();
            if (!String.IsNullOrEmpty(role))
            {
                RoleID = roleManager.Roles.SingleOrDefault(r => r.Name == role).Id;
            }

            MyUser = new UserEdit
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
                }).SingleOrDefaultAsync(m => m.Id == RoleID)
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

            if (!applicationUser.Editable)
            {
                return Page();
            }

            applicationUser.Name = MyUser.Name;
            applicationUser.UserName = MyUser.UserName;
            applicationUser.Email = MyUser.Email;

            try
            {
                await userManager.UpdateAsync(applicationUser);

                await userManager.RemoveFromRolesAsync(applicationUser, await userManager.GetRolesAsync(applicationUser));

                if(!String.IsNullOrEmpty(RoleID))
                {
                    await userManager.AddToRoleAsync(applicationUser, (await roleManager.FindByIdAsync(RoleID)).Name);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserExists(MyUser.Id))
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

        private async Task<bool> UserExists(string id)
        {
            return (await userManager.FindByIdAsync(id)) != null;
        }
    }
}
