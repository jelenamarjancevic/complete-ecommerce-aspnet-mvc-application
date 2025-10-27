using BeatPass.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeatPass.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist_Festival>().HasKey(af => new { af.ArtistId, af.FestivalId });
            modelBuilder.Entity<Artist_Festival>().HasOne(f => f.Artist).WithMany(af => af.Artists_Festivals)
                .HasForeignKey(f => f.ArtistId);
            modelBuilder.Entity<Artist_Festival>().HasOne(f => f.Festival).WithMany(af => af.Artists_Festivals)
                .HasForeignKey(f => f.FestivalId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Artist_Festival> Artists_Festivals { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Organization> Organizations { get; set; }


        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
