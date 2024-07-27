using FluentValidation.Results;
using HotelReservation.DataAccess.Repositories;
using HotelReservation.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservation.Busineess.Abstractions;
using HotelReservation.Business.Validator;

namespace HotelReservation.Business.Services
{
    public class BookingService : IManager<Booking>
    {
        private readonly BookingRepository _bookingRepository;
        public BookingService(BookingRepository repository)
        {
            _bookingRepository = repository;
        }
        public void Create(Booking entity)
        {
            BookingValidator bval = new BookingValidator();
            ValidationResult result = bval.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join(",", result.Errors));
            }
            _bookingRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            var book = _bookingRepository.GetByID(id);

            if (book.IsDeleted)
            {
                throw new Exception("Aktif olan bir kategori silinemez.");
            }
            _bookingRepository.Delete(id);
        }

        public IEnumerable<Booking> GetAll()
        {
            return _bookingRepository.GetAll();
        }

        public Booking GetByID(Guid id)
        {
            return _bookingRepository.GetByID(id);
        }

        public bool IfEntityExists(Booking entity)
        {
            return _bookingRepository
                .IfEntityExists(b => b.Guest.LastName == entity.Guest.LastName);
        }

        public void Update(Booking entity)
        {
            if (entity!=null)
            {
                _bookingRepository.Update(entity);
            }
        }
    }
}
