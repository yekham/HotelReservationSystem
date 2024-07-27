using HotelReservation.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities.Models
{
    public class RoomType:BaseEntitiy
    {
        public string? Name { get; set; }   
        public string? Description { get; set; }
        public int PricePerNight { get; set; }
        public int Capacity {  get; set; }
        public ICollection<Room>? Rooms { get; set; }
    }
}
