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
    public class MatchingModel : PageModel
    {
        private readonly MentoringApp.Data.ApplicationDbContext _context;

        public MatchingModel(MentoringApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            var question = await _context.Question.ToListAsync();
            var settingsList = await _context.Settings.ToListAsync();
            Settings settings;

            if(settingsList.Count == 0)
            {
                settings = new Settings();
                settings.facultyWeight = 0.5f;
                settings.programWeight = 0.5f;
                _context.Settings.Add(settings);
                await _context.SaveChangesAsync();
            }
            else
            {
                settings = settingsList[0];
            }

            return RedirectToPage("./Matches");
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    var question = await _context.Question.ToListAsync();
        //    var settingsList = await _context.Settings.ToListAsync();
        //    var settings = settingsList[0];
        //    //settings.facultyWeight;

            

        //    return RedirectToPage("./Index");
        //}
    }
}
