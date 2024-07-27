using HotelReservation.Busineess.Abstractions;
using HotelReservation.DataAccess.Repositories;
using HotelReservation.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Services
{
    public class BookingGuestService : IManager<BookingGuest>
    {
        private readonly BookingGuestRepository _bookingGuestRepository;
        public BookingGuestService(BookingGuestRepository repository)
        {
            _bookingGuestRepository= repository;
        }
        public void Create(BookingGuest entity)
        {
            _bookingGuestRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            var bguest = _bookingGuestRepository.GetByID(id);
            if (bguest.IsDeleted)
            {
                throw new Exception("Aktif olan bir kategori silinemez.");
            }
            _bookingGuestRepository.Delete(id);
        }

        public IEnumerable<BookingGuest> GetAll()
        {
            return _bookingGuestRepository.GetAll();
        }

        public BookingGuest GetByID(Guid id)
        {
            return _bookingGuestRepository.GetByID(id);
        }

        public bool IfEntityExists(BookingGuest entity)
        {
            return _bookingGuestRepository.IfEntityExists(bg => bg.Guest.LastName == entity.Guest.LastName);
        }

        public void Update(BookingGuest entity)
        {
            if (entity != null)
            {
                _bookingGuestRepository.Update(entity);
            }
        }
    }
}
