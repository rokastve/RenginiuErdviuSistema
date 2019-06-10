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
        public ActionResult Create(string id, string logedInUser)
        {
             return View(new Message(id, logedInUser));
        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(Message message)
        {
            List<Message> messageList = new List<Message>();
            using (DBEntities db = new DBEntities())
            {
                messageList = db.Message.ToList<Message>();
            }
            if (messageList.Count == 0)
                message.Message_ID = 0;
            if (messageList.Count > 0)
                message.Message_ID = messageList.Max(x => x.Message_ID) + 1;

            if (ModelState.IsValid)
            {
                using (DBEntities db = new DBEntities())
                {
                    db.Message.Add(message);
                    db.SaveChanges();
                }
                return RedirectToAction("UserList", "RegisteredUser");
            }
            return View(message);
        }

       
    }
}
