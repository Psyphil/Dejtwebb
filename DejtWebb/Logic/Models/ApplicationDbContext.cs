using System.Data.Entity;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasMany(x => x.Posts).WithRequired(x => x.Receiver);

            base.OnModelCreating(modelBuilder);
            
        }
        public DbSet<Post> Posts { get; set; }

        public DbSet<WebbDejt2.Models.Friend> Friends { get; set; }

        
    }
    public class MyInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(store);

            string[] sampleNames = new string[] { "Johan Gustafsson", "Anton Svensson", "Filip Johansson", "Erik Gunnarson", "Elin Andersson", "Anna Jonsson", "Sofia Niklasson", "Siv Nilsson", "Nils Jöns", "Isabelle Soldat" };

            for (int i = 0; i < 10; i++)
            {
                var ifHidden = false;
                if (i == 1)
                {
                    ifHidden = true;
                }
                else
                {
                    ifHidden = false;
                }
                var user = new ApplicationUser { Name = sampleNames[i], Age = (i+10)*2, Description = "testanvändare" , UserName = $"e{i}@e.e", Email = $"e{i}@e.e", Hidden= ifHidden };
                

                userManager.CreateAsync(user, "Admin123!").Wait();
            }
            
            base.Seed(context);
        }
    }
}