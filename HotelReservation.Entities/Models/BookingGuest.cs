using HotelReservation.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities.Models
{
    public class BookingGuest:BaseEntitiy
    {
        public Guid BookingID { get; set; }
        public Booking Booking { get; set; }

        public Guid GuestID { get; set; }

        public Guest Guest { get; set; }
    }
}
