using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentoringApp.Data;
using MentoringApp.Models;

namespace MentoringApp.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly MentoringApp.Data.ApplicationDbContext _context;

        public CreateModel(MentoringApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Question = _context.Question.ToList();

            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        public IList<Question> Question { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Student.Add(Student);
            await _context.SaveChangesAsync();

            var questions = await _context.Question.ToListAsync();
            foreach(Question q in questions)
            {
                Answer a = new Answer();
                a.AnswerText = String.Format("{0}", Request.Form[q.QuestionText]);
                a.StudentFk = Student;
                a.QuestionFk = q;

                _context.Answer.Add(a);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}