using FluentValidation.Results;
using HotelReservation.Busineess.Abstractions;
using HotelReservation.Business.Validator;
using HotelReservation.DataAccess.Repositories;
using HotelReservation.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Services
{
    public class GuestService : IManager<Guest>
    {
        private readonly GuestRepository _guestRepository;
        public GuestService(GuestRepository repository)
        {
            _guestRepository = repository;
        }
        public void Create(Guest entity)
        {
            GuestValidator gval = new GuestValidator();
            ValidationResult result = gval.Validate(entity);

            if (!result.IsValid)
            {
                throw new Exception(string.Join(",", result.Errors));
            }
            _guestRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            var guest = _guestRepository.GetByID(id);
            if (guest.IsDeleted)
            {
                throw new Exception("Aktif olan bir kategori silinemez.");
            }
            _guestRepository.Delete(id);
        }

        public IEnumerable<Guest> GetAll()
        {
            return _guestRepository.GetAll();
        }

        public Guest GetByID(Guid id)
        {
            return _guestRepository.GetByID(id);
        }

        public bool IfEntityExists(Guest entity)
        {
            return _guestRepository.IfEntityExists(g => g.LastName == entity.LastName);
        }

        public void Update(Guest entity)
        {
            if (entity != null)
            {
                _guestRepository.Update(entity);
            }
        }
    }
}
