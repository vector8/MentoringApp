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
    public class DetailsModel : PageModel
    {
        private readonly MentoringApp.Data.ApplicationDbContext _context;

        public DetailsModel(MentoringApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Mentee Mentee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mentee = await _context.Mentee.SingleOrDefaultAsync(m => m.ID == id);

            if (Mentee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
