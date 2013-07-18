using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWRDataAccess.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string TwoWordReview { get; set; }
        public Subject Subject { get; set; }
    }
}
