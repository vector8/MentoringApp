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
    public class CreateModel : PageModel
    {
        private readonly RoleManager<MentoringApp.Data.ApplicationRole> roleManager;

        public CreateModel(RoleManager<MentoringApp.Data.ApplicationRole> rm)
        {
            roleManager = rm;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Role Role { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ApplicationRole appRole = new ApplicationRole();
            appRole.Name = Role.RoleName;
            appRole.Description = Role.Description;
            appRole.Editable = true;

            await roleManager.CreateAsync(appRole);

            return RedirectToPage("./Index");
        }
    }
}