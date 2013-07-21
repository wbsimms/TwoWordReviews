using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWRDataAccess.Entities;

namespace TWRDataAccess.Repositories
{
    public interface IReviewRepository
    {
        Review AddReview(Review model);
        List<Review> GetAllReviews();
    }

    [Export(typeof(IReviewRepository))]
    public class ReviewRepository : IReviewRepository
    {

        public ReviewRepository()
        {
        }

        public Review AddReview(Review model)
        {

            Review toSave = new Review()
            {
                Subject = model.Subject,
                TwoWordReview = model.TwoWordReview
            };
            using (TWRContext context = new TWRContext())
            {
                Subject subject = context.Subjects.FirstOrDefault(s => s.Name == toSave.Subject.Name);
                if (subject != null)
                {
                    toSave.Subject = subject;
                }

                context.Reviews.Add(toSave);
                context.SaveChanges();
            }
            model.ReviewId = toSave.ReviewId;
            model.Subject.SubjectId = toSave.Subject.SubjectId;
            return model;
        }

        public List<Review> GetAllReviews()
        {
            using (TWRContext context = new TWRContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;
                context.Configuration.ValidateOnSaveEnabled = false;
                return context.Reviews.Include(r => r.Subject).AsNoTracking().ToList();
            }
        }
    }
}
