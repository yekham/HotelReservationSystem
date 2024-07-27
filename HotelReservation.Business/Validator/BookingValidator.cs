using FluentValidation;
using HotelReservation.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Validator
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(b => b.CheckinDate).NotEmpty
                ().WithMessage("Giris tarihinizi seciniz.");
            
            RuleFor(b => b.CheckoutDate).NotEmpty
                ().WithMessage("Cikis tarihinizi seciniz.");

        }
    }
}
