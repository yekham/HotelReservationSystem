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

            RuleFor(b => b.Guest.FirstName).NotEmpty
                ().WithMessage("Isim alanini doldurun.");

            RuleFor(b => b.Guest.LastName).NotEmpty
                ().WithMessage("Soyisim alanini doldurun.");

            RuleFor(b => b.Guest.Phone).NotEmpty
                 ().WithMessage("Telefon numaranizi giriniz.").MaximumLength(11).WithMessage("11 haneli telefon numaranizi yaziniz.");
            RuleFor(b => b.Guest.Address).NotEmpty
                    ().WithMessage("Adresiniz giriniz.");
            RuleFor(b => b.Guest.Email).NotEmpty
                ().WithMessage("Mail adresinizi giriniz.");
        }
    }
}
