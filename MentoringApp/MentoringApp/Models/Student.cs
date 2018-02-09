using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentoringApp.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Display(Name = "Student Number")]
        public string StudentNumber { get; set; }

        //[DataType(DataType.PhoneNumber)]
        //[Phone]
        //[DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:(###) ###-####}")]
        public string Phone { get; set; }

        [Required]
        public string Faculty { get; set; }

        [Required]
        public string Program { get; set; }

        [Required]
        [Display(Name = "Is Mentor?")]
        public bool IsMentor { get; set; }

        public bool containsSearchString(string searchString)
        {
            return (FirstName + " " + LastName + " " + Email + " " + StudentNumber + " " + Phone + " " + Faculty + " " + Program).Contains(searchString);
        }
    }
}
