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
    public class EditModel : PageModel
    {
        private readonly MentoringApp.Data.ApplicationDbContext _context;

        public EditModel(MentoringApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public IList<Question> Question { get; set; }

        public Dictionary<int, Answer> AnswerDict { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student.SingleOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }
            else
            {
                Question = await _context.Question.ToListAsync();

                AnswerDict = new Dictionary<int, Answer>();

                var answers = await _context.Answer.Where(a => a.StudentFk.ID == Student.ID).ToListAsync();

                foreach(Answer a in answers)
                {
                    AnswerDict[a.QuestionFk.ID] = a;
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Student).State = EntityState.Modified;

            Question = await _context.Question.ToListAsync();

            foreach (Question q in Question)
            {
                var answer = await _context.Answer.Where(a => a.StudentFk.ID == Student.ID && a.QuestionFk.ID == q.ID).SingleOrDefaultAsync();
                answer.AnswerText = String.Format("{0}", Request.Form[q.QuestionText]);
                _context.Answer.Update(answer);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.ID == id);
        }
    }
}
