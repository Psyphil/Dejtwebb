using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DejtWebb.Models
{
    public class Post
    {
        String Title { get; set; }
        String Text { get; set; }
        int id { get; set; }
        User author { get; set; }
        User userPage { get; set; }

        public Post()
        {

        }
    }
}