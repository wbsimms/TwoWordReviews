using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwoWordReviews.Models;
using TWRDataAccess;
using TWRDataAccess.Entities;
using TWRDataAccess.Types;
using TWRDataAccess.Utils;

namespace TwoWordReviews.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddReview(MainModel model)
        {
            if (ShouldSave(model))
            {
                using (TWRDataAccess.TWRContext context = new TWRContext())
                {
                    context.ReviewRepository.AddReview(new Review()
                    {
                        Subject = new Subject(){Name = model.Subject, SubjectType = EnumHelper<SubjectType>.StringToEnum(model.SelectedType)},
                        TwoWordReview = model.TwoWordReview,
                    });
                    context.SaveChanges();
                }
            }
            return View("AddReview", new MainModel());
        }

        public bool ShouldSave(MainModel model)
        {
            if (string.IsNullOrEmpty(model.Subject) || string.IsNullOrEmpty(model.TwoWordReview) ||
                string.IsNullOrEmpty(model.SelectedType)) return false;
            return true;
        }

    }
}
