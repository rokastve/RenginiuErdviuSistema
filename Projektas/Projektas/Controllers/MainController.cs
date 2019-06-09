using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projektas.Models;

namespace Projektas.Controllers
{
    public class MainController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            Login model = new Login();

            if (Session["LoginName"] != null)
            {
                model.LoginName = (string)Session["LoginName"];
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Login model)
        {
            string selectedLoginName = model.LoginName;

            Session["LoginName"] = selectedLoginName;

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}