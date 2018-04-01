using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentoringApp.Models
{
    public class Settings
    {
        public int ID { get; set; }

        public float facultyWeight { get; set; }

        public float programWeight { get; set; }
    }
}
