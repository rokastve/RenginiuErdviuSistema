using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projektas.Models;
namespace Projektas.Controllers
{
    public class DiscountController : Controller
    {
        // GET: Discount
        public ActionResult DiscountListView()
        {
            List<Discount> DiscountList = new List<Discount>();
            using (DBEntities db = new DBEntities())
            {
                DiscountList = db.Discount.ToList<Discount>();
            }
            return View(DiscountList);
        }

    }
}
