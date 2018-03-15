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
    public class EditModel : PageModel
    {
        private readonly MentoringApp.Data.ApplicationDbContext _context;

        public EditModel(MentoringApp.Data.ApplicationDbContext context)
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

        [BindProperty]
        public Question Question { get; set; }

        public List<SelectListItem> QuestionTypes { get; set; }

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(Question.ID))
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

        private bool QuestionExists(int id)
        {
            return _context.Question.Any(e => e.ID == id);
        }
    }
}
