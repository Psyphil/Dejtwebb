using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebbDejt2.Models
{
    public class Post
    {
        [Required]
        [StringLength(150)]
        public string Text { get; set; }

        public int Id { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
    }
}