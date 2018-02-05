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

        public IList<Student> Student { get;set; }
        public IList<Question> Question { get; set; }
        public Dictionary<string, string> AnswerDict { get; set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Student.ToListAsync();

            Question = await _context.Question.ToListAsync();

            var answers = await _context.Answer.ToListAsync();

            AnswerDict = new Dictionary<string, string>();

            foreach(Answer a in answers)
            {
                AnswerDict[a.QuestionFk.ID.ToString() + "-" + a.StudentFk.ID.ToString()] = a.AnswerText;
            }

            //StudentAnswerPair = new List<Tuple<Student, Answer>>();
            //foreach(Student s in Student)
            //{
            //    Answer ans = (await _context.Answer.Where(a => a.StudentFk.ID == s.ID).ToListAsync()).First();
            //    StudentAnswerPair.Add(new Tuple<Student, Answer>(s, ans));
            //}
        }
    }
}
