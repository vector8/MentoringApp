using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentoringApp.Models
{
    public class Question
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Question")]
        public string QuestionText { get; set; }
    }
}
