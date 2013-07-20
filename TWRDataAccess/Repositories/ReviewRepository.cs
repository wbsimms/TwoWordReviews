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
                context.Reviews.Add(toSave);
                context.SaveChanges();
            }
            model.ReviewId = toSave.ReviewId;
            return model;
        }
    }
}
