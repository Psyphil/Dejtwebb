using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebbDejt2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public int Age { get; set; }
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

        }



        public virtual ICollection<Post> Posts { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}