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
            return RedirectToAction("ReservationList", "Reservation");
        }

        // GET: EventSpaceReview/Create
        public ActionResult Create(int id, string logedInUser)
        {
            return View(new EventSpaceReview(id, logedInUser));
        }

        // POST: EventSpaceReview/Create
        [HttpPost]
        public ActionResult Create(EventSpaceReview review)
        {
            List<EventSpaceReview> eventSpaceReservationList = new List<EventSpaceReview>();
            using (DBEntities db = new DBEntities())
            {
                eventSpaceReservationList = db.EventSpaceReview.ToList<EventSpaceReview>();
            }
            if (eventSpaceReservationList.Count == 0)
                review.Code = 0;

            if (eventSpaceReservationList.Count > 0)
                review.Code = eventSpaceReservationList.Max(x => x.Code) + 1;
            if (ModelState.IsValid)
            {
                using (DBEntities db = new DBEntities())
                {
                    db.EventSpaceReview.Add(review);
                    db.SaveChanges();
                }
                return RedirectToAction("ReservationList", "Reservation");
            }
            return View(review);
        }

    }
}
