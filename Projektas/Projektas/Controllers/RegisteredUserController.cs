using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projektas.Models;
namespace Projektas.Controllers
{
    public class RegisteredUserController : Controller
    {
        // GET: RegisteredUser
        public ActionResult UserList()
        {
            List<RegisteredUser> userList = new List<RegisteredUser>();
            using (DBEntities db = new DBEntities())
            {
                userList = db.RegisteredUser.Where(w => db.Customer.Select(s => s.Username).Contains(w.Login_name)).ToList();
                return View(userList);
            }
            
        }
        public ActionResult SendMessage(string ID, string LogedInUser)
        {
            return RedirectToAction("Create", "Message", new {id = ID, logedInUser = LogedInUser });
        }
        public ActionResult BlockUser(string ID)
        {
            return null;
        }
    }
}