using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebbDejt2.Controllers
{
    public class UserListController : BaseController
    {
        // GET: UserList
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }
    }
}