using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MentoringApp.Models
{
    public class FileUpload
    {
        [Display(Name = "Title")]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Mentor Data")]
        public IFormFile UploadMentorData { get; set; }

        [Required]
        [Display(Name = "Mentee Data")]
        public IFormFile UploadMenteeData { get; set; }
    }
}