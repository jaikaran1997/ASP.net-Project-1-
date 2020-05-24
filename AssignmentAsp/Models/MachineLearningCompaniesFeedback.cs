using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AssignmentAsp.Models
{
    public class MachineLearningCompaniesFeedback
    {
        public int Id { get; set; }
        [Required] [Display(Name = "Date")] public DateTime PostDate { get; set; }
        [Required] [Display(Name = "Username")] public string UserName { get; set; }
        [Required] [Display(Name = "Heading")] public string TopicTitle { get; set; }
        [Required] [Display(Name = "Select a Company")] public string SelectCompany { get; set; }
        [Display(Name = "Feedback")] public string MessageContent { get; set; }
        [Display(Name = "StarRating")] [Range(0, 5)] public int Like { get; set; }
        [Display(Name = "Agree")] public int Agree { get; set; }
        [Display(Name = "Disagree")] public int Disagree { get; set; }
        public bool canIncreaseLike { get; set; }
        public bool canIncreaseHate { get; set; }
    }
}

