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

        // GET: UserOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserOrder/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
