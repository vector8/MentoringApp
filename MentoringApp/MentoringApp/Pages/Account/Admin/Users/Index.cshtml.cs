using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MentoringApp.Models;

namespace MentoringApp.Pages.Account.Admin.Users
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<MentoringApp.Data.ApplicationUser> userManager;
        private readonly RoleManager<MentoringApp.Data.ApplicationRole> roleManager;

        public IndexModel(UserManager<MentoringApp.Data.ApplicationUser> um, RoleManager<MentoringApp.Data.ApplicationRole> rm)
        {
            userManager = um;
            roleManager = rm;
        }

        public IList<User> Users { get; set; }
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

            var users = await userManager.Users.ToListAsync();
            Users = new List<User>();
            foreach (Data.ApplicationUser au in users)
            {
                string role = userManager.GetRolesAsync(au).Result.Single();

                User u = new User
                {
                    Id = au.Id,
                    Name = au.Name,
                    UserName = au.UserName,
                    Email = au.Email,
                    Editable = au.Editable,
                    Role = Roles.Where(r => r.RoleName == role).Single()
                };
                Users.Add(u);
            }
        }
    }
}