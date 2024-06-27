using DataAccess.Entites;
using DataAccess.SeedData;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class TourBookingContext : DbContext
    {
        public TourBookingContext(DbContextOptions<TourBookingContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Ticket> Payments { get; set; }
        public DbSet<TourGuide> TourGuides { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<CategoryTour> CategoryTours { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<TourImage> TourImages { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<TourLocation> TourLocations { get; set; }
        public DbSet<TourDetail> TourDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   // Configure foreign keys with no cascade delete

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Tour>()
                .HasOne(t => t.Admin)
                .WithMany()
                .HasForeignKey(t => t.CreateBy)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Tour>()
            .HasOne(t => t.TourDetail)
            .WithOne(td => td.Tour)
            .HasForeignKey<TourDetail>(td => td.TourId)
            .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TourLocation>()
                .HasOne(tl => tl.Tour)
                .WithMany()
                .HasForeignKey(tl => tl.TourId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TourLocation>()
                .HasOne(tl => tl.Location)
                .WithMany()
                .HasForeignKey(tl => tl.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
            // Cấu hình mối quan hệ một-một giữa Payment và User
            modelBuilder.Entity<Ticket>()
                .HasOne(p => p.User)
                .WithOne() // Một User chỉ có thể có một Payment
                .HasForeignKey<Ticket>(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            // Cấu hình mối quan hệ một-một giữa Payment và Tour
            modelBuilder.Entity<Ticket>()
                .HasOne(p => p.Tour)
                .WithOne() // Một Tour chỉ có thể có một Payment
                .HasForeignKey<Ticket>(p => p.TourId)
                .OnDelete(DeleteBehavior.Restrict);
            // Cấu hình mối quan hệ một-nhiều giữa Ticket và TourGuide mà không cần ICollection<TourGuide>
            modelBuilder.Entity<TourGuide>()
                .HasOne(tg => tg.Ticket)
                .WithMany()
                .HasForeignKey(tg => tg.TicketId)
                .OnDelete(DeleteBehavior.Restrict);
            // Định nghĩa mối quan hệ giữa User và RefreshToken
            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany() // Không cần thuộc tính điều hướng
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Seed();
        }
    }
}
