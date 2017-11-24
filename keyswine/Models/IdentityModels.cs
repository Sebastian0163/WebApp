using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace keyswine.Models
{
    // You can add profile data for the user by adding more properties to your UsersTables class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class UsersTables : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UsersTables> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<UsersTables>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }
        public DbSet<Winemaker> Winemakers { get; set; }
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Category> Categorys { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UsersTables>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UsersRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UsersLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UsersClaim").Property(p => p.Id).HasColumnName("UsersClaimId");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles").Property(p => p.Id).HasColumnName("RoleId");
        }
    }
}