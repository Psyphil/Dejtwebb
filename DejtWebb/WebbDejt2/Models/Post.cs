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
        public ApplicationUser Author { get; set; }
        public ApplicationUser Receiver { get; set; }
    }

    //////public class PostDbContext : IdentityDbContext<ApplicationUser>
    //////{
    //////    public PostDbContext()
    //////    {

    //////    }

    //////}
}