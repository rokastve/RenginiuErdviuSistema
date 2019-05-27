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

        // GET: UserOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserOrder/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserOrder/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
