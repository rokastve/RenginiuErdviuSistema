using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projektas.Models;


namespace Projektas.Controllers
{
    public class SpaceController : Controller
    {
        // GET: EventSpace
        public ActionResult EventSpaceList()
        {
            List<EventSpace> eventSpaceList = new List<EventSpace>();
            using (DBEntities db = new DBEntities())
            {
                eventSpaceList = db.EventSpace.ToList<EventSpace>();
            }
                return View(eventSpaceList);
        }

        // GET Adresses
        public ActionResult EventSpaceMapView()
        {
            List<EventSpace> eventSpaceList = new List<EventSpace>();
            List<String> addresses = new List<String>();

            using (DBEntities db = new DBEntities())
            {
                eventSpaceList = db.EventSpace.ToList<EventSpace>();
            }

            for (int i = 0; i < eventSpaceList.Count(); i++)
                addresses.Add(eventSpaceList[i].Address);

            return View(addresses);
        }
    }
}