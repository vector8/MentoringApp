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
    public class IndexModel : PageModel
    {
        private readonly MentoringApp.Data.ApplicationDbContext _context;

        public IndexModel(MentoringApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Mentee> Mentee { get;set; }

        public async Task OnGetAsync()
        {
            Mentee = await _context.Mentee.ToListAsync();
        }
    }
}
