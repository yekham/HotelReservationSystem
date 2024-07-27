using HotelReservation.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingGuest> BookingGuests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelReservationSystem2;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingGuest>()
                .HasKey(bg => new { bg.BookingID, bg.GuestID });

            modelBuilder.Entity<BookingGuest>()
                .HasOne(bg => bg.Booking)
                .WithMany(b => b.BookingGuests)
                .HasForeignKey(bg => bg.BookingID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingGuest>()
                .HasOne(bg => bg.Guest)
                .WithMany(g => g.BookingGuests)
                .HasForeignKey(bg => bg.GuestID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingGuest>().Ignore(b => b.Id);

            modelBuilder.Entity<Room>()
                .HasKey(r => r.Id);

        }






    }
}
