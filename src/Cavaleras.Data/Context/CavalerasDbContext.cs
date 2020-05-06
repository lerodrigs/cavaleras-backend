using Calaveras.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Cavaleras.Data.Context
{
    public class CavalerasDbContext: IdentityDbContext
    {
        private readonly IConfiguration _configuration;

        public CavalerasDbContext() { }
        public CavalerasDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public DbSet<User> User { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<DeliveryMan> DeliveryMen { get; set; }
        public DbSet<ZipCode> ZipCodes { get; set; }
        public DbSet<ZipCodeDeliveryPrice> ZipCodeDeliveryPrices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("cavaleras"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType()));
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>(identityRole => { identityRole.ToTable("Roles", "auth"); });
            modelBuilder.Entity<IdentityUser>(IdentityUser => { IdentityUser.ToTable("Users", "auth"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(identityRoleClaim => { identityRoleClaim.ToTable("RolesClaims", "auth"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(identityUserClaim => { identityUserClaim.ToTable("UsersClaims", "auth"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(identityUserLogin => { identityUserLogin.ToTable("UsersLogins", "auth"); });
            modelBuilder.Entity<IdentityUserRole<string>>(identityUserRole => { identityUserRole.ToTable("UsersRoles", "auth"); });
            modelBuilder.Entity<IdentityUserToken<string>>(identityUserToken => { identityUserToken.ToTable("UsersTokens", "auth"); });
        }
    }
}
