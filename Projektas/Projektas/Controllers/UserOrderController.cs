using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projektas.Models;

namespace Projektas.Controllers
{
    public class UserOrderController : Controller
    {
        // GET: UserOrder
        public ActionResult UserOrderListView()
        {
            List<UserOrder> UserOrderList = new List<UserOrder>();
            using (DBEntities db = new DBEntities())
            {
                UserOrderList = db.UserOrder.ToList<UserOrder>();
            }
            return View(UserOrderList);
        }

        // GET: UserOrder/Create
        public void CreateFromFoodOrder(int userOrderId, DataView dw)
        {
            UserOrder autoCreated = new UserOrder(userOrderId, dw.model.UserOrder);
            using (DBEntities db = new DBEntities())
            {
                db.UserOrder.Add(autoCreated);
                db.SaveChanges();
            }
        }

        // GET: UserOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserOrder/Edit/5
        public ActionResult Edit(int id)
        {
            DataView dView = new DataView();
            List<SelectListItem> items = new List<SelectListItem>();
            List<Reservation> reservationList = new List<Reservation>();
            using (DBEntities db = new DBEntities())
            {
                reservationList = db.Reservation.ToList<Reservation>();
                for (int i = 0; i < reservationList.Count; i++)
                {
                    if (reservationList[i].Reserver == Session["LoginName"].ToString())
                    {
                        dView.userReservationList.Add(reservationList[i]);
                        items.Add(new SelectListItem { Text = reservationList[i].Code.ToString(), Value = reservationList[i].Code.ToString() });
                    }
                }
            }
            dView.reservationIds = new SelectList(items, "Value", "Text");

            using (DBEntities db = new DBEntities())
            {
                dView.userOrderModel = db.UserOrder.Where(x => x.Order_code == id).FirstOrDefault();
            }
            
            return View(dView);
        }

        // POST: UserOrder/Edit/5
        [HttpPost]
        public ActionResult Edit(UserOrder userOrderModel)
        {
            using (DBEntities db = new DBEntities())
            {
                db.Entry(userOrderModel).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("UserOrderListView");
        }

        // GET: UserOrder/Cancel
        public ActionResult Cancel(int id)
        {
            UserOrder userOrderModel = new UserOrder();
            using (DBEntities db = new DBEntities())
            {
                userOrderModel = db.UserOrder.Where(x => x.Order_code == id).FirstOrDefault();
            }
            return View(userOrderModel);
        }

        // POST: UserOrder/Cancel
        [HttpPost]
        public ActionResult Cancel(int id, FormCollection collection)
        {
            using (DBEntities db = new DBEntities())
            {
                UserOrder userOrderModel = db.UserOrder.Where(x => x.Order_code == id).FirstOrDefault();
                db.UserOrder.Remove(userOrderModel);
                db.SaveChanges();
            }
            return RedirectToAction("UserOrderListView");
        }
    }
}
