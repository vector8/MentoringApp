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

namespace MentoringApp.Pages.Questions
{
    public class CreateModel : PageModel
    {
        private readonly MentoringApp.Data.ApplicationDbContext _context;

        public CreateModel(MentoringApp.Data.ApplicationDbContext context)
        {
            _context = context;
            QuestionTypes = new List<SelectListItem>();

            var values = Enum.GetValues(typeof(Question.QuestionType)).Cast<Question.QuestionType>();

            foreach (var v in values)
            {
                SelectListItem item = new SelectListItem
                {
                    Text = Question.GetDescription(v),
                    Value = v.ToString()
                };

                QuestionTypes.Add(item);
            }
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Question Question { get; set; }

        public List<SelectListItem> QuestionTypes { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Question.Add(Question);

            var students = await _context.Student.ToListAsync();

            foreach(Student s in students)
            {
                Answer a = new Answer();
                a.QuestionFk = Question;
                a.StudentFk = s;
                a.AnswerText = "";

                _context.Answer.Add(a);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}