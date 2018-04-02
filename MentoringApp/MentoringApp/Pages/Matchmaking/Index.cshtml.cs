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
    public class IndexModel : PageModel
    {
        private readonly MentoringApp.Data.ApplicationDbContext _context;

        private struct MatchValue
        {
            public Student mentee;
            public float value;
        }

        public IndexModel(MentoringApp.Data.ApplicationDbContext context)
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
            var mentors = await _context.Student.Where(s => s.IsMentor && s.Match == null).ToListAsync();
            var mentees = await _context.Student.Where(s => !s.IsMentor && s.Match == null).ToListAsync();

            string facultyWeight = Request.Form["facultyWeight"];

            float fWeight = float.Parse(facultyWeight);

            settings.facultyWeight = fWeight;

            foreach(Question q in question)
            {
                q.Weight = float.Parse(Request.Form["question" + q.ID.ToString() + "Weight"]);
            }

            await _context.SaveChangesAsync();

            int groupSize = mentees.Count() / mentors.Count();

            for(int i = 0; i < mentors.Count(); i++)
            {
                Match match = new Match();
                _context.Match.Add(match);
                await _context.SaveChangesAsync();

                mentors[i].Match = match;

                var mentorAnswers = await _context.Answer.Where(a => a.StudentFk.ID == mentors[i].ID).ToListAsync();

                List<MatchValue> matchValues = new List<MatchValue>();

                foreach (Student mentee in mentees)
                {
                    if (mentee.Match != null)
                        continue;

                    MatchValue matchValue = new MatchValue();
                    matchValue.mentee = mentee;

                    if(mentors[i].Faculty == mentee.Faculty)
                    {
                        matchValue.value += fWeight;
                    }
                    
                    // Calculate match value between mentor and mentee
                    foreach(Answer mentorAnswer in mentorAnswers)
                    {
                        var menteeAnswer = await _context.Answer.Where(a => a.StudentFk.ID == mentee.ID && a.QuestionFk.ID == mentorAnswer.QuestionFk.ID).SingleAsync();

                        if(menteeAnswer.AnswerText.Equals(mentorAnswer.AnswerText))
                        {
                            matchValue.value += (menteeAnswer.QuestionFk.Weight);
                        }
                        // else matchValue is 0
                    }

                    matchValues.Add(matchValue);
                }

                matchValues.Sort(delegate (MatchValue x, MatchValue y)
                {
                    return -1 * x.value.CompareTo(y.value);
                });

                int tempSize = groupSize;
                if(i == mentors.Count() - 1)    // This is the last mentor, add all mentees to the group
                {
                    tempSize = matchValues.Count();
                }

                for(int j = 0; j < tempSize; j++)
                {
                    matchValues[j].mentee.Match = match;
                    //mentees.Remove(matchValues[j].mentee);
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Matches");
        }
    }
}
