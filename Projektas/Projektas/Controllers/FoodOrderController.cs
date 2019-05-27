using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projektas.Models;

namespace Projektas.Controllers
{
    public class FoodOrderController : Controller
    {
        // GET: FoodOrder
        public ActionResult Index()
        {
            return View();
        }

        // GET: FoodOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Cancel()
        {
            return RedirectToAction("FoodSupplierList", "FoodSupplier");
        }

        // GET: FoodOrder/Create
        public ActionResult Create(string id)
        {
            return View(new FoodOrder(id));
        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(FoodOrder foodOrder)
        {
            using (DBEntities db = new DBEntities())
            {
                db.FoodOrder.Add(foodOrder);
                db.SaveChanges();
            }
            return RedirectToAction("FoodSupplierList", "FoodSupplier");
        }
    }
}
