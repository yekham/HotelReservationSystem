using HotelReservation.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities.Models
{
    public class Payment:BaseEntitiy
    {
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }
        public Guid BookingID {  get; set; }
        public Booking? Booking { get; set; }
    }
}
