using HotelReservation.DataAccess.Context;
using HotelReservation.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Repositories
{
    public class BookingRepository : GenericRepository<Booking>
    {
        public BookingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
