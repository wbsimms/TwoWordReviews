using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwoWordReviews.Models;

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

        public ActionResult AddReview()
        {
            return View("AddReview", new MainModel());
        }

    }
}
