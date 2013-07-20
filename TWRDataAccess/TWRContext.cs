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
        private CompositionContainer container;
        public TWRContext() : base("name=DefaultConnection")
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(TWRContext).Assembly));

            container = new CompositionContainer(catalog);

            try
            {
                this.container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        [Import]
        public IReviewRepository ReviewRepository { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
