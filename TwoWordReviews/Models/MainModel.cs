using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public string TwoWordReview { get; set; }
    }
}