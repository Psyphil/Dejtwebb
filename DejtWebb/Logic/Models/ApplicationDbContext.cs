﻿using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebbDejt2.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)// hur man gör 1 -> M enligt sista föreläsningen
        {
            modelBuilder.Entity<ApplicationUser>().HasMany(x => x.Posts).WithRequired(x => x.Receiver);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Post> Posts { get; set; }

        //public System.Data.Entity.DbSet<WebbDejt2.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
    public class MyInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(store);

            for (int i = 0; i < 10; i++)
            {
                var user = new ApplicationUser { Name = $"User{i}", Age = i, Description = "test användare" , UserName = $"e{i}@e.e", Email = $"e{i}@e.e" };
                userManager.CreateAsync(user, "Admin1!").Wait();
            }
            



            base.Seed(context);
        }
    }
}