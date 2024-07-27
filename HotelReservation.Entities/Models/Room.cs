using HotelReservation.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities.Models
{
    public class Room : BaseEntitiy
    {
        [Key] 
        public new int Id { get; set; }
        public string? Status { get; set; }
        public Guid HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public Guid RoomTypeID { get; set; }
        public RoomType? RoomType { get; set; }

        public ICollection<Booking>? Bookings { get; set; }

    }
}
