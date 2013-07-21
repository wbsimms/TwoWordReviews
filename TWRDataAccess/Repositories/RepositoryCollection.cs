using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWRDataAccess.Repositories
{
    public interface IRepositoryCollection
    {
        [Import]
        IReviewRepository ReviewRepository { get; set; }

        [Import]
        ISubjectRepository SubjectRepository { get; set; }
    }

    [Export(typeof(IRepositoryCollection))]
    public class RepositoryCollection : IRepositoryCollection
    {
//        private CompositionContainer container;

        public RepositoryCollection()
        {
            //var catalog = new AggregateCatalog();
            //catalog.Catalogs.Add(new AssemblyCatalog(typeof(TWRContext).Assembly));

            //container = new CompositionContainer(catalog);

            //try
            //{
            //    this.container.ComposeParts(this);
            //}
            //catch (CompositionException compositionException)
            //{
            //    Console.WriteLine(compositionException.ToString());
            //}
        }

        [Import]
        public IReviewRepository ReviewRepository { get; set; }

        [Import]
        public ISubjectRepository SubjectRepository { get; set; }

    }
}
