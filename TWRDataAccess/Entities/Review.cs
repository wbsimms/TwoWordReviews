using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWRDataAccess.Types;

namespace TWRDataAccess.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        [MaxLength(300)]
        public string TwoWordReview { get; set; }
        public Subject Subject { get; set; }

        public User User { get; set; }
    }
}
