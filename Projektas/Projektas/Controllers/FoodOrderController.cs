using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
            dView.model = new FoodOrder(id);
            return View(dView);

        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(DataView dw)
        {
            int userOrderId = 0;
            UserOrderController temp = new UserOrderController();
            List<UserOrder> userOrderList = new List<UserOrder>();
            using (DBEntities db = new DBEntities())
            {
                userOrderList = db.UserOrder.ToList<UserOrder>();
            }
            if (userOrderList.Count == 0)
                userOrderId = 0;
            if (userOrderList.Count > 0)
                userOrderId = userOrderList.Max(x => x.Order_code) + 1;

            temp.CreateFromFoodOrder(userOrderId, dw);
            dw.model.Order_id = GetIndex();
                using (DBEntities db = new DBEntities())
                {
                    db.FoodOrder.Add(dw.model);
                    db.SaveChanges();
                }
            return RedirectToAction("FoodSupplierList", "FoodSupplier");
        }

        public int GetIndex()
        {
            int index = 0;
            List<FoodOrder> foodOrderList = new List<FoodOrder>();
            using (DBEntities db = new DBEntities())
            {
                foodOrderList = db.FoodOrder.ToList<FoodOrder>();
            }
            if (foodOrderList.Count == 0)
                index = 0;
            if (foodOrderList.Count > 0)
                index = foodOrderList.Max(x => x.Order_id) + 1;

            return index;
        }
    }
}
