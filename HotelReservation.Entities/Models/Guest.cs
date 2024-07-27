using HotelReservation.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities.Models
{
    public class Guest:BaseEntitiy
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address {  get; set; }    
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<BookingGuest>? BookingGuests { get; set; }


    }
}
