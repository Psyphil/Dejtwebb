using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebbDejt2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(16, 150)]
        public int Age { get; set; }

        [StringLength(150)]
        public string Description { get; set; }
        public bool Hidden { get; set; }
        public string ImgName { get; set; }
        public string ImgType { get; set; }
        public byte[] ImgFile { get; set; }

        public ApplicationUser()
        {
            //string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\profilepic.jpg";
            string fileName = "profilepic.jpg";
            string pathDirectory = System.AppContext.BaseDirectory;
            string path = Path.Combine(pathDirectory, @"pictures\", fileName);
            var DefaultImg = File.OpenRead(path);
            ImgName = "Default";
            ImgType = "JPG";

            using (var reader = new BinaryReader(DefaultImg))
            {
                ImgFile = reader.ReadBytes(int.Parse(DefaultImg.Length.ToString()));
            }

            FriendRequestsSent = new List<Friend>();
            FriendRequestsReceived = new List<Friend>();

        }



        public virtual ICollection<Post> Posts { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<Friend> FriendRequestsSent { get; set; }
        public virtual ICollection<Friend> FriendRequestsReceived { get; set; }
    }

    public class Friend
    {
        [Key/*, Column(Order = 0)*/]
        public string keyId { get; set; }
        //[Key, Column(Order = 1)]
        //public string receiverId { get; set; }
        
        public virtual ApplicationUser Sender { get; set; }
        public virtual ApplicationUser Receiver { get; set; }

        public bool FriendAccepted { get; set; }

        public Friend(ApplicationUser From, ApplicationUser To)
        {
            this.FriendAccepted = false;
            this.Sender = From;
            this.Receiver = To;
            this.keyId = From.Id + To.Id;
            //this.receiverId = To.Id;
        }
    }
}