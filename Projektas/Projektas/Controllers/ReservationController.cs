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
            using (DBEntities db = new DBEntities())
            {
                reservationList = db.Reservation.ToList<Reservation>();
            }
            return View(reservationList);
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
    }
}
