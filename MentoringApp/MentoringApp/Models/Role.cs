using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentoringApp.Models
{
    public class Role
    {
        public string Id { get; set; }
        [Display(Name = "Role")]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool Editable { get; set; }
    }
}
