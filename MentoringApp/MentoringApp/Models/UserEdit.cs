using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentoringApp.Models
{
    public class UserEdit
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public bool Editable { get; set; }
        public Role Role { get; set; }
    }
}
