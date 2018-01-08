using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using WebbDejt2.Models;

namespace WebbDejt2.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        
        }

        public ActionResult _ExampleUsers()
        {
            var users = db.Users.ToList();
            List<ApplicationUser> exampleUsers = new List<ApplicationUser>();
            for (int i = 0; i < 4; i++)
            {
                exampleUsers.Add(users[i]);
            }
            return PartialView(exampleUsers);
        }
    }
}