using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWRDataAccess.Entities;
using TWRDataAccess.Repositories;
using TWRDataAccess.Types;

namespace TWRDataAccess
{
    public class TWRContext : DbContext
    {
        public TWRContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Review> Reviews { get; set;}
        public DbSet<Subject> Subjects { get; set; }

    }
}
