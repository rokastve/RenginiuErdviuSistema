using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projektas.Models;

namespace Projektas.Controllers
{
    public class EquipmentController : Controller
    {
        // GET: Equipment
        public ActionResult Index(int id)
        {
            TempData["Id"] = id;
            List<Equipment> listEq = new List<Equipment>();
            using (DBEntities db = new DBEntities())
            {
                listEq = db.Equipment.ToList<Equipment>();
                return View(listEq);
            }
                
        }

        [HttpPost]
        public ActionResult Add(IEnumerable<int> equipmentIdToAdd)
        {
            List<Equipment> selected = new List<Equipment>();
            using (DBEntities db = new DBEntities())
            {
                selected = db.Equipment.Where(x => equipmentIdToAdd.Contains(x.Code)).ToList<Equipment>();
                TempData["Things"] = selected;
            }
            int idret = (int)TempData["Id"];
            return RedirectToAction("Add", "EquipmentOrder", new  {id = idret });
        }
    }
}
