using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MentoringApp.Models
{
    public class Question
    {
        public int ID { get; set; }

        public enum QuestionType
        {
            [Description("Yes or No")]
            Binary,
            [Description("Range of Values")]
            Range,
            [Description("Plain Text")]
            PlainText
        }

        public static string GetDescription(QuestionType enumerationValue)
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }

        public string GetDescriptionNonStatic(QuestionType enumerationValue)
        {
            return Question.GetDescription(enumerationValue);
        }

        [Required]
        [Display(Name = "Question")]
        public string QuestionText { get; set; }

        public QuestionType Type { get; set; }

        // Ranges from 0 (least important) to 1 (most important)
        public float Weight { get; set; }
    }
}
