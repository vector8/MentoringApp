using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MentoringApp.Data;
using MentoringApp.Models;

namespace MentoringApp.Pages.Mentees
{
    public class DeleteAllModel : PageModel
    {
        private readonly MentoringApp.Data.ApplicationDbContext _context;

        public DeleteAllModel(MentoringApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Database.ExecuteSqlCommand("delete from Mentee");
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
