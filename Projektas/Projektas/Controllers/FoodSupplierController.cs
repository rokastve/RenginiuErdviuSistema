using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projektas.Models;

namespace Projektas.Controllers
{
    public class FoodSupplierController : Controller
    {
        // GET: FoodSupplier
        public ActionResult FoodSupplierList()
        {
            List<FoodSupplier> foodSupplierList = new List<FoodSupplier>();
            using (DBEntities db = new DBEntities())
            {
                foodSupplierList = db.FoodSupplier.ToList<FoodSupplier>();
            }
            return View(foodSupplierList);
        }

        public ActionResult Order(string ID)
        {
            return RedirectToAction("Create", "FoodOrder", new { id = ID });
        }
    }
}
