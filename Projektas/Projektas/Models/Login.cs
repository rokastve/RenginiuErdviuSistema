using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projektas.Models
{
    public class Login
    {
        public string LoginName { get; set; }
        public SelectList LoginNames { get; set; }

        public Login()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<RegisteredUser> userList = new List<RegisteredUser>();
            using (DBEntities db = new DBEntities())
            {
                userList = db.RegisteredUser.ToList<RegisteredUser>();
                for (int i = 0; i < userList.Count; i++)
                {
                    items.Add(new SelectListItem { Text = userList[i].Login_name.ToString(), Value = userList[i].Login_name.ToString() });
                }
            }
            this.LoginNames = new SelectList(items, "Value", "Text");
        }
    }
}