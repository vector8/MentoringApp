using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MentoringApp.Data
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }

        public bool Editable { get; set; }
    }
}
