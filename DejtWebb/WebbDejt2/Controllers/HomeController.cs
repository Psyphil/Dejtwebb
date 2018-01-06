using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbDejt2.Models;

namespace WebbDejt2.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ExampleUsers()
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