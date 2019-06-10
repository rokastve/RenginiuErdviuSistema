using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projektas.Models;

namespace Projektas.Controllers
{
    public class EquipmentOrderController : Controller
    {
        // GET: EquipmentOrder
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(int id)
        {
            List<Equipment> things = (List<Equipment>)TempData["Things"];
            foreach (Equipment eq in things)
            {
                UserOrder UO = new UserOrder();
                List<UserOrder> UserOrderList = new List<UserOrder>();
                using (DBEntities db = new DBEntities())
                {
                    UserOrderList = db.UserOrder.ToList<UserOrder>();

                    if (UserOrderList.Count == 0)
                        UO.Order_code = 0;

                    if (UserOrderList.Count > 0)
                        UO.Order_code = UserOrderList.Max(x => x.Order_code) + 1;
                    UO.Reservation = id;
                    db.UserOrder.Add(UO);
                    db.SaveChanges();
                    EquipmentOrder order = new EquipmentOrder(eq.Code, UO.Order_code);
                    db.EquipmentOrder.Add(order);
                    db.SaveChanges();
                }
            }
            return null;
        }

        // GET: EquimentOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EquimentOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquimentOrder/Create
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

        // GET: EquimentOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EquimentOrder/Edit/5
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

        // GET: EquimentOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EquimentOrder/Delete/5
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
