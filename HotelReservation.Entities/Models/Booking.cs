using HotelReservation.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities.Models
{
    public class Booking:BaseEntitiy
    {

        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int TotalPrice { get; set; }
        public Guest? Guest { get; set; }
        public Guid GuestID { get; set; }
        public Room? Room { get; set; }
        public int RoomID { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<BookingGuest>? BookingGuests { get; set; }
    }
}
