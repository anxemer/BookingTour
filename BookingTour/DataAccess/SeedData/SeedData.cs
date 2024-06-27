using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SeedData
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "admin123", Email = "admin@example.com", Role = "Admin", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Fullname = "Admin User", DoB = new DateTime(1990, 1, 1), Address = "123 Admin St", Phone = "1234567890", Status = "Active" },
                new User { Id = 2, Username = "user1", Password = "user123", Email = "user1@example.com", Role = "User", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Fullname = "Regular User", DoB = new DateTime(1995, 5, 15), Address = "456 User Ave", Phone = "9876543210", Status = "Active" },
                new User { Id = 3, Username = "guide1", Password = "guide123", Email = "guide1@example.com", Role = "Guide", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Fullname = "Tour Guide", DoB = new DateTime(1988, 10, 20), Address = "789 Guide Rd", Phone = "5555555555", Status = "Active" }
            );

            // Locations
            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, CreateBy = 1, Name = "Paris", Address = "Paris, France", Description = "City of Love", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Status = "Active" },
                new Location { Id = 2, CreateBy = 1, Name = "Tokyo", Address = "Tokyo, Japan", Description = "Vibrant Metropolis", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Status = "Active" },
                new Location { Id = 3, CreateBy = 1, Name = "New York", Address = "New York, USA", Description = "The Big Apple", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Status = "Active" }
            );

            // Tours
            modelBuilder.Entity<Tour>().HasData(
                new Tour { Id = 1, HotelId = 1, CreateBy = 1, CategoryTourId = 1, Name = "Eiffel Tower Adventure", Description = "Explore the iconic Eiffel Tower", Price = 100, TotalDay = "1", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, StartDay = DateTime.Now.AddDays(30), Status = "Available" },
                new Tour { Id = 2, HotelId = 2, CreateBy = 1, CategoryTourId = 2, Name = "Tokyo Sushi Experience", Description = "Taste the best sushi in Tokyo", Price = 150, TotalDay = "2", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, StartDay = DateTime.Now.AddDays(45), Status = "Available" },
                new Tour { Id = 3, HotelId = 3, CreateBy = 1, CategoryTourId = 3, Name = "NYC Broadway Show", Description = "Enjoy a Broadway musical in New York", Price = 200, TotalDay = "3", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, StartDay = DateTime.Now.AddDays(60), Status = "Available" }
            );

            // TourLocations
            modelBuilder.Entity<TourLocation>().HasData(
                new TourLocation { Id = 1, TourId = 1, LocationId = 1,Status = "ACTIVE" },
                new TourLocation { Id = 2, TourId = 2, LocationId = 2, Status = "ACTIVE" },
                new TourLocation { Id = 3, TourId = 3, LocationId = 3, Status = "ACTIVE" }
            );

            // TourImages
            modelBuilder.Entity<TourImage>().HasData(
                new TourImage { Id = 1, TourId = 1, Url = "https://example.com/eiffel.jpg"},
                new TourImage {Id = 2, TourId = 2, Url = "https://example.com/sushi.jpg" },
                new TourImage {Id = 3, TourId = 3, Url = "https://example.com/broadway.jpg" }
            );

            // Bookings
            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = 1, UserId = 2, TourId = 1, Status = "Confirmed", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Booking { Id = 2, UserId = 2, TourId = 2, Status = "Pending", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Booking { Id = 3, UserId = 3, TourId = 3, Status = "Confirmed", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );

            // TourGuides
            modelBuilder.Entity<TourGuide>().HasData(
                new TourGuide { Id = 1, Fullname = "John Doe", Phone = "1112223333", Email = "john@example.com", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now,  Status = "Available" },
                new TourGuide { Id = 2, Fullname = "Jane Smith", Phone = "4445556666", Email = "jane@example.com", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Status = "Available" },
                new TourGuide { Id = 3, Fullname = "Mike Johnson", Phone = "7778889999", Email = "mike@example.com", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Status = "Busy" }
            );

            // Hotels
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Luxury Paris Hotel", Address = "1 Champs-Élysées, Paris", CreateBy = 1, Description = "5-star hotel in the heart of Paris", TotalRoom = 200, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Status = "Open" },
                new Hotel { Id = 2, Name = "Tokyo Skyline Hotel", Address = "1-1-1 Shibuya, Tokyo", CreateBy = 1, Description = "Modern hotel with a view of Tokyo skyline", TotalRoom = 300, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Status = "Open" },
                new Hotel { Id = 3, Name = "New York Plaza", Address = "5th Avenue, New York", CreateBy = 1, Description = "Iconic New York hotel", TotalRoom = 400, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Status = "Open" }
            );

            // HotelImages
            modelBuilder.Entity<HotelImage>().HasData(
                new HotelImage {Id = 1, HotelId = 1, Url = "https://example.com/paris_hotel.jpg" },
                new HotelImage {Id = 2, HotelId = 2, Url = "https://example.com/tokyo_hotel.jpg" },
                new HotelImage
                {
                    Id = 3,
                    HotelId = 3,
                    
                    Url = "https://example.com/nyc"
                });
            modelBuilder.Entity<CategoryTour>().HasData(
           new CategoryTour
           {
               Id = 1,
               Name = "Adventure Tours",
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now,
               Status = "Active"
           },
           new CategoryTour
           {
               Id = 2,
               Name = "Cultural Tours",
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now,
               Status = "Active"
           },
           new CategoryTour
           {
               Id = 3,
               Name = "Beach Vacations",
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now,
               Status = "Active"
           },
           new CategoryTour
           {
               Id = 4,
               Name = "City Breaks",
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now,
               Status = "Active"
           }
       );
        }
    }
}

