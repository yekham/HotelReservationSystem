using HotelReservation.DataAccess.Context;
using HotelReservation.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Repositories
{
    public class RoomRepository : GenericRepository<Room>
    {
        public RoomRepository(ApplicationDbContext context) : base(context)
        {
        }
        public IEnumerable<Room> GetAllWithRoomTypes()
        {
            return _context.Rooms.Include(r => r.RoomType).ToList();
        }
    }
}
