using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MentoringApp.Data;
using MentoringApp.Models;

namespace MentoringApp.Pages.Questions
{
    public class DeleteModel : PageModel
    {
        private readonly MentoringApp.Data.ApplicationDbContext _context;

        public DeleteModel(MentoringApp.Data.ApplicationDbContext context)
        {
            _context = context;

            var values = Enum.GetValues(typeof(Question.QuestionType)).Cast<Question.QuestionType>();

            QuestionTypeText = new String[values.Count()];

            for (int i = 0; i < values.Count(); i++)
            {
                QuestionTypeText[i] = Question.GetDescription(values.ElementAt(i));
            }
        }

        [BindProperty]
        public Question Question { get; set; }

        public String[] QuestionTypeText { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Question = await _context.Question.SingleOrDefaultAsync(m => m.ID == id);

            if (Question == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Question = await _context.Question.FindAsync(id);

            if (Question != null)
            {
                var answers = await _context.Answer.Where(a => a.QuestionFk.ID == Question.ID).ToListAsync();
                _context.Answer.RemoveRange(answers);

                _context.Question.Remove(Question);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
