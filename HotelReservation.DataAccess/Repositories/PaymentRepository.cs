using HotelReservation.DataAccess.Context;
using HotelReservation.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>
    {
        public PaymentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
