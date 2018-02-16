using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MentoringApp.Models;
using MentoringApp.Utilities;

namespace MentoringApp.Pages.Students
{
    public class BulkUploadModel : PageModel
    {
        private readonly MentoringApp.Data.ApplicationDbContext _context;

        public BulkUploadModel(MentoringApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FileUpload FileUpload { get; set; }

        public IList<Student> Student { get; private set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Perform an initial check to catch FileUpload class
            // attribute violations.
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var menteeFileContents =
                await FileHelpers.ProcessFormFile(FileUpload.UploadMenteeData, ModelState);

            var mentorFileContents =
                await FileHelpers.ProcessFormFile(FileUpload.UploadMentorData, ModelState);

            // Perform a second check to catch ProcessFormFile method
            // violations.
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await parseFile(menteeFileContents, false);

            await parseFile(mentorFileContents, true);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private async Task parseFile(string fileContents, bool isMentor)
        {
            string[] lines = fileContents.Split("\n");
            string[] fields = lines[0].Split("\t");
            var questions = await _context.Question.ToListAsync();
            Dictionary<int, Question> questionsDict = new Dictionary<int, Question>();

            for (int i = 0; i < fields.Length; i++)
            {
                fields[i] = fields[i].Trim('"');
                var matchingQuestions = questions.Where(q => q.QuestionText == fields[i]);

                if (matchingQuestions.Count() > 0)
                {
                    questionsDict[i] = matchingQuestions.First();
                }
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string[] attributes = lines[i].Split("\t");

                if (attributes.Length < 10)
                    continue;

                var student = new Student()
                {
                    FirstName = attributes[4],
                    LastName = attributes[5],
                    Email = attributes[6],
                    Phone = attributes[7],
                    Faculty = attributes[8],
                    Program = attributes[9]
                };

                student.IsMentor = isMentor;

                _context.Student.Add(student);

                for (int j = 10; j < attributes.Length; j++)
                {
                    if (questionsDict.ContainsKey(j))
                    {
                        Answer a = new Answer();
                        a.QuestionFk = questionsDict[j];
                        a.StudentFk = student;
                        a.AnswerText = attributes[j];
                        _context.Answer.Add(a);
                    }
                }
            }
        }
    }
}