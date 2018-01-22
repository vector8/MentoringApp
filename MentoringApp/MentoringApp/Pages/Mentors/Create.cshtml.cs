using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MentoringApp.Data;
using MentoringApp.Models;

namespace MentoringApp.Pages.Mentors
{
    public class CreateModel : PageModel
    {
        private readonly MentoringApp.Data.ApplicationDbContext _context;

        public CreateModel(MentoringApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Mentor Mentor { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Mentor.Add(Mentor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}