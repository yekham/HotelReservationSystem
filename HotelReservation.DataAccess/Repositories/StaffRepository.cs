using HotelReservation.DataAccess.Context;
using HotelReservation.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Repositories
{
    public class StaffRepository : GenericRepository<Staff>
    {
        public StaffRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
