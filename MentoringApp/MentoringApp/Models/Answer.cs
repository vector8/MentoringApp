using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentoringApp.Models
{
    public class Answer
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Question")]
        public Question QuestionFk { get; set; }

        [Required]
        [Display(Name = "Student")]
        public Student StudentFk { get; set; }

        [Required]
        [Display(Name = "Answer")]
        public string AnswerText { get; set; }
    }
}
