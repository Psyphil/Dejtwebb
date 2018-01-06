using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebbDejt2.Models
{
    public class Post
    {
        public string Text { get; set; }
        public int Id { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual ApplicationUser Receiver { get; set; }

        public string renewDatabase { get; set; }

    }
}