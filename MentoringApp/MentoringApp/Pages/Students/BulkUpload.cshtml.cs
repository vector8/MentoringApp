using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

            // Perform a second check to catch ProcessFormFile method
            // violations.
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string[] lines = menteeFileContents.Split("\n");
            for (int i = 1; i < lines.Length; i++)
            {
                string[] attributes = lines[i].Split("\t");

                if (attributes.Length < 87)
                {
                    continue;
                }

                var mentee = new Student()
                {
                    FirstName = attributes[4],
                    LastName = attributes[5],
                    Email = attributes[6],
                    Phone = attributes[7],
                    Faculty = attributes[8],
                    Program = attributes[9]//,
                    //IsGrad = attributes[18] == "Checked" ? "Yes" : "No",
                    //IsInternational = attributes[25] == "International" ? "Yes" : "No",
                    //IsExchange = attributes[25] == "Exchange" ? "Yes" : "No",
                    //IsMature = attributes[32] == "Checked" ? "Yes" : "No",
                    //IsTransfer = attributes[33] == "Checked" ? "Yes" : "No",
                    //IsPathways = attributes[34] == "Checked" ? "Yes" : "No",
                    //IsIndigenous = attributes[21] == "Checked" ? "Yes" : "No",
                    //IsFirstGen = attributes[22] == "Checked" ? "Yes" : "No",
                    //CountryOfOrigin = attributes[27],
                    //MeetOtherStudentsInFaculty = attributes[37],
                    //MeetOtherStudentsCommute = attributes[38],
                    //MeetOtherStudentsOnCampus = attributes[39],
                    //MeetOtherStudentsOffCampus = attributes[40],
                    //MeetOtherStudentsTransfer = attributes[41],
                    //MeetOtherStudents21 = attributes[42],
                    //MeetOtherStudentsInt = attributes[43],
                    //MeetOtherStudentsClasses = attributes[44],
                    //MeetOtherStudentsClubs = attributes[45],
                    //MeetOtherStudentsIndigenous = attributes[46],
                    //MeetOtherStudentsFirstGen = attributes[47],
                    //WorksHard = attributes[48],
                    //Thoughtful = attributes[49],
                    //AppreciatesNature = attributes[50],
                    //HelpsOthers = attributes[51],
                    //QuickToTrust = attributes[52],
                    //EnjoysDiscovering = attributes[53],
                    //HandlesStressWell = attributes[54],
                    //IsAthletic = attributes[55],
                    //DoesWhatTheyWant = attributes[56],
                    //RespectsTraditions = attributes[57],
                    //NeedsQuietTime = attributes[58],
                    //MeetsResponsibilities = attributes[59],
                    //UnderstandScienceMath = attributes[60],
                    //LivesInHarmony = attributes[61],
                    //IsCheerful = attributes[62],
                    //IsReserved = attributes[63],
                    //KeepsRoomTidy = attributes[64],
                    //GenderIdentity = attributes[65],
                    //SexualOrientation = attributes[66],
                    //Religion = attributes[86],
                    //Languages = attributes[87],
                    //CanContact = attributes[88]
                };

                _context.Student.Add(mentee);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}