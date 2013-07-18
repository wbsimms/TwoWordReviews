using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}