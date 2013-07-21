﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View();
        }

        [HttpGet]
        public ActionResult AddReview()
        {
            MainModel mainModel = new MainModel();
            mainModel.AllReviews = Repositories.ReviewRepository.GetAllReviews();
            return View("AddReview", mainModel);
        }

        [HttpPost]
        public ActionResult AddReview(MainModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AllReviews = Repositories.ReviewRepository.GetAllReviews();
                return View("AddReview", model);
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
            return View("AddReview", mainModel);
        }

        public bool ShouldSave(MainModel model)
        {
            if (string.IsNullOrEmpty(model.Subject) || string.IsNullOrEmpty(model.TwoWordReview) ||
                string.IsNullOrEmpty(model.SelectedType)) return false;
            return true;
        }

    }
}
