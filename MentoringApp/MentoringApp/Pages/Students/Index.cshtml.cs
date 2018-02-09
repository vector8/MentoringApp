using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MentoringApp.Data;
using MentoringApp.Models;

namespace MentoringApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly MentoringApp.Data.ApplicationDbContext _context;

        public IndexModel(MentoringApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; }
        public IList<Question> Question { get; set; }
        public Dictionary<string, string> AnswerDict { get; set; }

        public async Task OnGetAsync(string searchString, string typeOfStudent)
        {
            //Student = new List<Models.Student>();

            var students = from s in _context.Student
                           select s;

            if (typeOfStudent == "Mentee")
            {
                students = students.Where(s => s.IsMentor == false);
            }
            else if (typeOfStudent == "Mentor")
            {
                students = students.Where(s => s.IsMentor == true);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.containsSearchString(searchString));
            }

            Student = await students.ToListAsync();

            Question = await _context.Question.ToListAsync();

            var answerSelect = from a in _context.Answer
                               join s in students on a.StudentFk.ID equals s.ID
                               select a;
            var answers = await answerSelect.ToListAsync();

            AnswerDict = new Dictionary<string, string>();

            foreach (Answer a in answers)
            {
                AnswerDict[a.QuestionFk.ID.ToString() + "-" + a.StudentFk.ID.ToString()] = a.AnswerText;
            }
        }
    }
}
