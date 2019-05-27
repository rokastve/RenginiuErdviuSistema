using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projektas.Models;

namespace Projektas.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }

        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Cancel()
        {
            return RedirectToAction("UserList", "RegisteredUser");
        }

        // GET: Message/Create
        public ActionResult Create(string id)
        {
             return View(new Message(id));
        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(Message message)
        {
            using (DBEntities db = new DBEntities())
            {
                db.Message.Add(message);
                db.SaveChanges();
            }
            return RedirectToAction("UserList", "RegisterUser");
        }

       
    }
}
