using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MentoringApp.Data;
using MentoringApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MentoringApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly MentoringApp.Data.ApplicationDbContext _context;

        public IndexModel(MentoringApp.Data.ApplicationDbContext context)
        {
            _context = context;
            StudentTypes = new SelectList(new List<string>{ "Any", "Mentee", "Mentor" });
            TopList = new SelectList(new List<string> { "25", "50", "75", "100", "All" });
        }

        public string filterString { get; set; }
        public SelectList StudentTypes { get; set; }
        public string studentType { get; set; }
        public IList<Student> Student { get; set; }
        public IList<Question> Question { get; set; }
        public Dictionary<string, string> AnswerDict { get; set; }
        public SelectList TopList { get; set; }
        public string top { get; set; }
        public int TotalCount { get; set; }
        public int DisplayedCount { get; set; }

        public async Task OnGetAsync(string searchString, string studentType, string top)
        {
            //Student = new List<Models.Student>();

            filterString = searchString;
            this.studentType = studentType;
            this.top = top;

            var students = from s in _context.Student
                           select s;

            if (studentType == "Mentee")
            {
                students = students.Where(s => s.IsMentor == false);
            }
            else if (studentType == "Mentor")
            {
                students = students.Where(s => s.IsMentor == true);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.containsSearchString(searchString));
            }

            TotalCount = students.Count();

            int topInt;
            if(!String.IsNullOrEmpty(top) && int.TryParse(top, out topInt))
            {
                students = students.Take(topInt);
                DisplayedCount = topInt;
            }
            else
            {
                DisplayedCount = TotalCount;
            }

            if(DisplayedCount > TotalCount)
            {
                DisplayedCount = TotalCount;
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
                if(a.QuestionFk != null && a.StudentFk != null)
                {
                    AnswerDict[a.QuestionFk.ID.ToString() + "-" + a.StudentFk.ID.ToString()] = a.AnswerText;
                }
            }
        }
    }
}
