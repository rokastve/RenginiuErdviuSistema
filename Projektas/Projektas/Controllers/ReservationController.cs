using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projektas.Models;

namespace Projektas.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult ReservationList()
        {
            List<Reservation> reservationList = new List<Reservation>();
            List<Reservation> userReservationList = new List<Reservation>();
            using (DBEntities db = new DBEntities())
            {
                reservationList = db.Reservation.ToList<Reservation>();
                for (int i = 0; i < reservationList.Count; i++)
                {
                    if (reservationList[i].Reserver == Session["LoginName"].ToString())
                        userReservationList.Add(reservationList[i]);
                }
            }
            return View(userReservationList);
        }
        public ActionResult LeaveReview(int ID, string LogedInUser)
        {
            return RedirectToAction("Create", "EventSpaceReview", new { id = ID, logedInUser = LogedInUser });
        }

        // Get: Reservation/Cancel
        public ActionResult Cancel(int id)
        {
            Reservation reservationModel = new Reservation();
            using (DBEntities db = new DBEntities())
            {
                reservationModel = db.Reservation.Where(x => x.Code == id).FirstOrDefault();
            }
            return View(reservationModel);
        }

        // Post: Reservation/Cancel
        [HttpPost]
        public ActionResult Cancel(int id, FormCollection collection)
        {
            using (DBEntities db = new DBEntities())
            {
                Reservation reservationModel = db.Reservation.Where(x => x.Code == id).FirstOrDefault();
                db.Reservation.Remove(reservationModel);
                db.SaveChanges();
            }
            return RedirectToAction("ReservationList");
        }

        public ActionResult Create(int id, string logedInUser)
        {
            return View(new Reservation(id, logedInUser));
        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(Reservation reservation)
        {
            List<Reservation> reservationList = new List<Reservation>();
            using (DBEntities db = new DBEntities())
            {
                reservationList = db.Reservation.ToList<Reservation>();
            }
            if (reservationList.Count >= 0)
                reservation.Code = reservationList.Max(x => x.Code) + 1;

            using (DBEntities db = new DBEntities())
            {
                db.Reservation.Add(reservation);
                db.SaveChanges();
            }
            return RedirectToAction("EventSpaceList", "Space");
        }
        public ActionResult Return()
        {
            return RedirectToAction("EventSpaceList", "Space");
        }
        public ActionResult Details(int? id)
        {
            Reservation reservationModel = new Reservation();
            using (DBEntities db = new DBEntities())
            {
                reservationModel = db.Reservation.Where(x => x.Code == id).FirstOrDefault();
            }
            return View(reservationModel);
        }
    }
}
