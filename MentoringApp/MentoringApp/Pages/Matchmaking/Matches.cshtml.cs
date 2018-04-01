using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MentoringApp.Data;
using MentoringApp.Models;

namespace MentoringApp.Pages.Matchmaking
{
    public class MatchesModel : PageModel
    {
        private readonly MentoringApp.Data.ApplicationDbContext _context;

        public MatchesModel(MentoringApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Student> student { get;set; }

        public async Task OnGetAsync()
        {
            student = await _context.Student.ToListAsync();
        }
    }
}
