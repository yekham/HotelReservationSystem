using HotelReservation.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities.Models
{
    public class Hotel:BaseEntitiy
    {

        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int Stars { get; set; }
        public ICollection<Staff>? Staffs { get; set; }
        public ICollection<Room>? Rooms { get; set; }


    }
}
