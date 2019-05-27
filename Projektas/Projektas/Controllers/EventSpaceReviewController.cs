using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projektas.Models;

namespace Projektas.Controllers
{
    public class EventSpaceReviewController : Controller
    {
        // GET: EventSpaceReview
        public ActionResult Index()
        {
            return View();
        }

        // GET: EventSpaceReview/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Cancel()
        {
            return RedirectToAction("UserOrderListView", "UserOrder");
        }

        // GET: EventSpaceReview/Create
        public ActionResult Create(string id)
        {
            return View(new EventSpaceReview(id));
        }

        // POST: EventSpaceReview/Create
        [HttpPost]
        public ActionResult Create(EventSpaceReview review)
        {
            using (DBEntities db = new DBEntities())
            {
                db.EventSpaceReview.Add(review);
                db.SaveChanges();
            }
            return RedirectToAction("UserOrderListView", "UserOrder");
        }

    }
}
