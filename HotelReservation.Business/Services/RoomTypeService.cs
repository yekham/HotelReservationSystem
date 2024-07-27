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
    public class RoomTypeService : IManager<RoomType>
    {
        private readonly RoomTypeRepository _roomTypeRepository;
        public RoomTypeService(RoomTypeRepository repository)
        {
            _roomTypeRepository = repository;
        }
        public void Create(RoomType entity)
        {

            _roomTypeRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            var room = _roomTypeRepository.GetByID(id);
            if (room.IsDeleted)
            {
                throw new Exception("Aktif olan bir kategori silinemez.");
            }
            _roomTypeRepository.Delete(id);
        }

        public IEnumerable<RoomType> GetAll()
        {
            return _roomTypeRepository.GetAll();
        }

        public RoomType GetByID(Guid id)
        {
            return _roomTypeRepository.GetByID(id);
        }

        public bool IfEntityExists(RoomType entity)
        {
            return _roomTypeRepository.IfEntityExists(r => r.Name == entity.Name);
        }

        public void Update(RoomType entity)
        {
            if (entity != null)
            {
                _roomTypeRepository.Update(entity);
            }
        }
    }
}
