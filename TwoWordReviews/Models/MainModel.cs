using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWRDataAccess.Entities;
using TWRDataAccess.Types;
using TWRDataAccess.Utils;

namespace TwoWordReviews.Models
{
    public class MainModel
    {
        public IList<string> SubjectTypes { get; set; }
        public MainModel()
        {
            SubjectTypes = EnumHelper<SubjectType>.EnumToList();
        }

        [Required]
        public string SelectedType { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [RegularExpression("\\w+\\s\\w+",ErrorMessage = "Review must contain two words")]
        public string TwoWordReview { get; set; }

        public List<Review> AllReviews { get; set; }
    }
}