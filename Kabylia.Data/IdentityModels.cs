using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Kabylia.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }


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
        public DbSet<Customer> Customers { get; set; } //DB Set for CUstomer
        public DbSet<Restaurant> Restaurants { get; set; } //DB Set for Restaurant
        public DbSet<DeliveryDriver> DeliveryDrivers { get; set; } //DB Set for DeliveryDriver
        public DbSet<Order> Orders{ get; set; } //DB Set for Order
        public DbSet<Transaction> Transactions { get; set; } //DB Set for Transaction
        public DbSet<Menu> Menu { get; set; } //DB Set for Menu
        public DbSet<Area> Area { get; set; } //DB Set for Area
        public DbSet<Review> Review { get; set; } //DB Set for Area
        public DbSet<Rating> Rating { get; set; } //DB Set for Area
        




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();
            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<Order>()
            //   .HasRequired(f => f.Status)
            //   .WithRequiredDependent()
            //   .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Restaurant>()
            //   .HasRequired(f => f.Status)
            //   .WithRequiredDependent()
            //   .WillCascadeOnDelete(false);
        }
    }

    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }

}