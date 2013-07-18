using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWRDataAccess.Entities;
using TWRDataAccess.Types;

namespace TWRDataAccess
{
    public class TWRContext : DbContext
    {
        public TWRContext() : base()
        {
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
