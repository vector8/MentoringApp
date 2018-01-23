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

        [Display(Name ="Identifies as Woman")]
        public bool? IsWoman { get; set; }

        public string Allergies { get; set; }

        [Display(Name ="Dietary Requirements")]
        public string DietaryRequirements { get; set; }

        [Display(Name = "Connect With Peers Priority")]
        public string ConnectWithPeersPriority { get; set; }

        [Display(Name = "Learn Expectations Priority")]
        public string LearnExpectationsPriority { get; set; }

        [Display(Name = "Gain Program Info Priority")]
        public string GainProgramInfoPriority { get; set; }

        [Display(Name = "Learn About Campus Services Priority")]
        public string LearnCampusServicesPriority { get; set; }

        [Display(Name = "Connect With Upper Years Priority")]
        public string ConnectWithUpperYearsPriority { get; set; }

        [Display(Name = "Identifies as Grad Student")]
        public bool? IsGrad { get; set; }

        [Display(Name = "International or Exchange")]
        public string IsInternationalOrExchange { get; set; }   // null if neither

        [Display(Name = "Identifies as Mature Student")]
        public bool? IsMature { get; set; }

        [Display(Name = "Identifies as Transfer Student")]
        public bool? IsTransfer { get; set; }

        [Display(Name = "Identifies as Pathways Student")]
        public bool? IsPathways { get; set; }

        [Display(Name = "Identifies as Indigenous")]
        public bool? IsIndigenous { get; set; }

        [Display(Name = "Identifies as First Gen Student")]
        public bool? IsFirstGen { get; set; }

        [Display(Name = "Will Attend Ignite")]
        public bool? WillAttendIgnite { get; set; }

        [Display(Name ="Reg. for Int. Orientation")]
        public bool? InternationalStudentOrientation { get; set; }

        [Display(Name = "Country of Origin")]
        public string CountryOfOrigin { get; set; }

        [Display(Name = "Reg. for NASP Program")]
        public bool? NaspProgram { get; set; }

        [Display(Name = "Arriving in Canada")]
        public DateTime? ArriveInCanada { get; set; }

        [Display(Name = "NASP Reg. Date")]
        public DateTime? NaspRegisterDate { get; set; }

        [Display(Name = "Prev. Institution")]
        public string PrevInstitution { get; set; }

        [Display(Name = "Reg. for MTPS Orientation")]
        public bool? MtpsOrientation { get; set; }

        [Display(Name = "Meet Other Students in Faculty")]
        public string MeetOtherStudentsInFaculty { get; set; }

        [Display(Name = "Meet Other Students Who Commute")]
        public string MeetOtherStudentsCommute { get; set; }

        [Display(Name = "Meet Other Students On Campus")]
        public string MeetOtherStudentsOnCampus { get; set; }

        [Display(Name = "Meet Other Students Off Campus")]
        public string MeetOtherStudentsOffCampus { get; set; }

        [Display(Name = "Meet Other Transfer Students")]
        public string MeetOtherStudentsTransfer { get; set; }

        [Display(Name = "Meet Other Students Over 21")]
        public string MeetOtherStudents21 { get; set; }

        [Display(Name = "Meet Other Int. Students")]
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

        [Display(Name = "Religion")]
        public string Religion { get; set; }

        public string Languages { get; set; }

        [Display(Name = "Can Contact")]
        public bool? CanContact { get; set; }
    }
}
