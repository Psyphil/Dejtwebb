using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DejtWebb.Models
{
    public class User
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public int Id { get; set; }
        public List<User> Friends { get; set; }

        public User()
        {

        }

    }
}