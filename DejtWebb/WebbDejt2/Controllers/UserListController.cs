using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbDejt2.Models;

namespace WebbDejt2.Controllers
{
    public class UserListController : BaseController
    {
        //the first parameter is the option that we choose and the second parameter will use the textbox value  
        public ActionResult Index(string search)
        {

            if( search == null)
            {
                var userList = db.Users.Where(x => x.Hidden.Equals(false)).ToList();
                return View(userList);
            }
            //if a user choose the radio button option as Subject  
            var users = db.Users.Where(x => x.Name.Contains(search)).ToList();

            List<ApplicationUser> usersVisible = new List<ApplicationUser>();
            foreach( ApplicationUser u in users)
            {
                if( u.Hidden == false)
                {
                    usersVisible.Add(u);
                }
            }
                return View(usersVisible);
        }

        public ActionResult StartIndex()
        {
            var users = db.Users.ToList();
            List<ApplicationUser> exampelUsers = new List<ApplicationUser>();
            for ( int i = 0; i < 6; i++)
            {
                exampelUsers.Add(users[i]);
            }
            return View(exampelUsers);
        }
    }
}