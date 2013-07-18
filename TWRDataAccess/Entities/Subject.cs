using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWRDataAccess.Types;

namespace TWRDataAccess.Entities
{
    public class Subject
    {
        public Subject()
        {
        }

        public int SubjectId { get; set; }
        public string Name { get; set; }
        public SubjectType SubjectType { get; set; }
    }
}
