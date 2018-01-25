using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentoringApp.Models
{
    public class Mentee
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

        //[DataType(DataType.PhoneNumber)]
        //[Phone]
        //[DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:(###) ###-####}")]
        public string Phone { get; set; }

        [Required]
        public string Faculty { get; set; }

        [Required]
        public string Program { get; set; }

        [Display(Name = "Grad Student")]
        public string IsGrad { get; set; }

        [Display(Name = "International Student")]
        public string IsInternational { get; set; }

        [Display(Name = "Exchange Student")]
        public string IsExchange { get; set; }

        [Display(Name = "Mature Student")]
        public string IsMature { get; set; }

        [Display(Name = "Transfer Student")]
        public string IsTransfer { get; set; }

        [Display(Name = "Pathways Student")]
        public string IsPathways { get; set; }

        [Display(Name = "Indigenous Student")]
        public string IsIndigenous { get; set; }

        [Display(Name = "First Gen Student")]
        public string IsFirstGen { get; set; }

        [Display(Name = "Country of Origin")]
        public string CountryOfOrigin { get; set; }

        [Display(Name = "Meet Students in Faculty")]
        public string MeetOtherStudentsInFaculty { get; set; }

        [Display(Name = "Meet Students Who Commute")]
        public string MeetOtherStudentsCommute { get; set; }

        [Display(Name = "Meet Students On Campus")]
        public string MeetOtherStudentsOnCampus { get; set; }

        [Display(Name = "Meet Students Off Campus")]
        public string MeetOtherStudentsOffCampus { get; set; }

        [Display(Name = "Meet Transfer Students")]
        public string MeetOtherStudentsTransfer { get; set; }

        [Display(Name = "Meet Mature Students")]
        public string MeetOtherStudents21 { get; set; }

        [Display(Name = "Meet Int. Students")]
        public string MeetOtherStudentsInt { get; set; }

        [Display(Name = "Meet Students In Classes")]
        public string MeetOtherStudentsClasses { get; set; }

        [Display(Name = "Meet Students In Clubs")]
        public string MeetOtherStudentsClubs { get; set; }

        [Display(Name = "Meet Indigenous Students")]
        public string MeetOtherStudentsIndigenous { get; set; }

        [Display(Name = "Meet First Gen Students")]
        public string MeetOtherStudentsFirstGen { get; set; }

        [Display(Name = "Works Hard")]
        public string WorksHard { get; set; }

        [Display(Name = "Thoughtful")]
        public string Thoughtful { get; set; }

        [Display(Name = "Appreciates Nature")]
        public string AppreciatesNature { get; set; }

        [Display(Name = "Helps Others")]
        public string HelpsOthers { get; set; }

        [Display(Name = "Quick to Trust")]
        public string QuickToTrust { get; set; }

        [Display(Name = "Enjoys Discovering")]
        public string EnjoysDiscovering { get; set; }

        [Display(Name = "Handles Stress Well")]
        public string HandlesStressWell { get; set; }

        [Display(Name = "Is Athletic")]
        public string IsAthletic { get; set; }

        [Display(Name = "Does What They Want")]
        public string DoesWhatTheyWant { get; set; }

        [Display(Name = "Respects Traditions")]
        public string RespectsTraditions { get; set; }

        [Display(Name = "Needs Quiet Time")]
        public string NeedsQuietTime { get; set; }

        [Display(Name = "Meets Responsibilities")]
        public string MeetsResponsibilities { get; set; }

        [Display(Name = "Wants to Understand Science/Math")]
        public string UnderstandScienceMath { get; set; }

        [Display(Name = "Lives in Harmony")]
        public string LivesInHarmony { get; set; }

        [Display(Name = "Is Cheerful")]
        public string IsCheerful { get; set; }

        [Display(Name = "Is Reserved")]
        public string IsReserved { get; set; }

        [Display(Name = "Keeps Room Tidy")]
        public string KeepsRoomTidy { get; set; }

        [Display(Name = "Gender Identity")]
        public string GenderIdentity { get; set; }

        [Display(Name = "Sexual Orientation")]
        public string SexualOrientation { get; set; }

        [Display(Name = "Racial Identity")]
        public string RacialIdentity { get; set; }

        public string Religion { get; set; }

        public string Languages { get; set; }

        [Display(Name = "Can Contact")]
        public string CanContact { get; set; }
    }
}
