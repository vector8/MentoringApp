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
using Microsoft.Extensions.Logging;

namespace MentoringApp.Pages.Account.Admin.Users
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<MentoringApp.Data.ApplicationUser> userManager;
        private readonly RoleManager<MentoringApp.Data.ApplicationRole> roleManager;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(UserManager<MentoringApp.Data.ApplicationUser> um, RoleManager<MentoringApp.Data.ApplicationRole> rm, ILogger<CreateModel> logger)
        {
            userManager = um;
            roleManager = rm;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            Roles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();

            return Page();
        }

        [BindProperty]
        public UserCreate MyUser { get; set; }

        [BindProperty]
        public List<SelectListItem> Roles { get; set; }

        [BindProperty]
        public string RoleID { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ApplicationUser appUser = new ApplicationUser();
            appUser.Name = MyUser.Name;
            appUser.UserName = MyUser.UserName;
            appUser.Email = MyUser.Email;
            appUser.Editable = true;

            var result = await userManager.CreateAsync(appUser, MyUser.Password);
            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");

                if (!String.IsNullOrEmpty(RoleID))
                {
                    await userManager.AddToRoleAsync(appUser, (await roleManager.FindByIdAsync(RoleID)).Name);
                }

                return RedirectToPage("./Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            Roles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();

            return Page();
        }
    }
}