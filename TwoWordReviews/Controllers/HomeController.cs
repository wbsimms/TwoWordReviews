using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TwoWordReviews.Models;
using TWRDataAccess;
using TWRDataAccess.Entities;
using TWRDataAccess.Repositories;
using TWRDataAccess.Types;
using TWRDataAccess.Utils;

namespace TwoWordReviews.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [Import(typeof(IRepositoryCollection))]
        public IRepositoryCollection Repositories { get; set; }

        public ActionResult Index()
        {
            MainModel mainModel = new MainModel();
            mainModel.AllReviews = Repositories.ReviewRepository.GetAllReviews();
            return View("Index", mainModel);
        }

        [HttpPost]
        public ActionResult AddReview(MainModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AllReviews = Repositories.ReviewRepository.GetAllReviews();
                return View("Index", model);
            }
            if (ShouldSave(model))
            {
                Repositories.ReviewRepository.AddReview(new Review()
                {
                    Subject = new Subject(){Name = model.Subject, SubjectType = EnumHelper<SubjectType>.StringToEnum(model.SelectedType)},
                    TwoWordReview = model.TwoWordReview,
                });
            }
            MainModel mainModel = new MainModel();
            mainModel.AllReviews = Repositories.ReviewRepository.GetAllReviews();
            return View("Index", mainModel);
        }

        public bool ShouldSave(MainModel model)
        {
            if (string.IsNullOrEmpty(model.Subject) || string.IsNullOrEmpty(model.TwoWordReview) ||
                string.IsNullOrEmpty(model.SelectedType)) return false;
            return true;
        }

    }
}
