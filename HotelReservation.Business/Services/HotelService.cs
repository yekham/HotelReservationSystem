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
    public class HotelService : IManager<Hotel>
    {
        private readonly HotelRepository _hotelRepository;
        public HotelService(HotelRepository repository)
        {
            _hotelRepository = repository;
        }
        public void Create(Hotel entity)
        {

            _hotelRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            var hotel = _hotelRepository.GetByID(id);
            if (hotel.IsDeleted)
            {
                throw new Exception("Aktif olan bir kategori silinemez.");
            }
            _hotelRepository.Delete(id);
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _hotelRepository.GetAll();
        }

        public Hotel GetByID(Guid id)
        {
            return _hotelRepository.GetByID(id);
        }

        public bool IfEntityExists(Hotel entity)
        {
            return _hotelRepository.IfEntityExists(h => h.Name == entity.Name);
        }

        public void Update(Hotel entity)
        {
            if (entity != null)
            {
                _hotelRepository.Update(entity);
            }
        }
    }
}
