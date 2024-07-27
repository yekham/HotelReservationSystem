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
    public class HotelRepository : GenericRepository<Hotel>
    {
        public HotelRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
