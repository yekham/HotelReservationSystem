using FluentValidation;
using HotelReservation.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Validator
{
    public class GuestValidator:AbstractValidator<Guest>
    {
        public GuestValidator()
        {
            RuleFor(b => b.FirstName).NotEmpty
                ().WithMessage("Isim alanini doldurun.");
            
            RuleFor(b => b.LastName).NotEmpty
                ().WithMessage("Soyisim alanini doldurun.");

            RuleFor(b => b.Phone).NotEmpty
                 ().WithMessage("Telefon numaranizi giriniz.").MaximumLength(11).WithMessage("11 haneli telefon numaranizi yaziniz.");
            RuleFor(b => b.Address).NotEmpty
                    ().WithMessage("Adresiniz giriniz.");
            RuleFor(b => b.Email).NotEmpty
                ().WithMessage("Mail adresinizi giriniz.");
        }
    }
}
