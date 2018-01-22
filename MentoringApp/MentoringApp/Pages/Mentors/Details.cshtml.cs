using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MentoringApp.Data;
using MentoringApp.Models;

namespace MentoringApp.Pages.Mentors
{
    public class DetailsModel : PageModel
    {
        private readonly MentoringApp.Data.ApplicationDbContext _context;

        public DetailsModel(MentoringApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Mentor Mentor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mentor = await _context.Mentor.SingleOrDefaultAsync(m => m.ID == id);

            if (Mentor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
