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

            var values = Enum.GetValues(typeof(Question.QuestionType)).Cast<Question.QuestionType>();

            QuestionTypeText = new String[values.Count()];

            for(int i = 0; i < values.Count(); i++)
            {
                QuestionTypeText[i] = Question.GetDescription(values.ElementAt(i));
            }
        }

        public IList<Question> question { get;set; }

        public Settings settings { get; set; }

        public String[] QuestionTypeText { get; set; }

        public async Task OnGetAsync()
        {
            question = await _context.Question.ToListAsync();
            var settingsList = await _context.Settings.ToListAsync();

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
        }

        public string getQuestionWeightName(int questionID)
        {
            return "question" + questionID.ToString() + "Weight";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            question = await _context.Question.ToListAsync();
            var settingsList = await _context.Settings.ToListAsync();
            settings = settingsList[0];

            string facultyWeight = Request.Form["facultyWeight"];

            float fWeight = float.Parse(facultyWeight);

            settings.facultyWeight = fWeight;

            foreach(Question q in question)
            {
                q.Weight = float.Parse(Request.Form["question" + q.ID.ToString() + "Weight"]);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
