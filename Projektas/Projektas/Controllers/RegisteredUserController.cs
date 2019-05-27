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
                userList = db.RegisteredUser.ToList<RegisteredUser>();
            }
                return View(userList);
        }
    }
}