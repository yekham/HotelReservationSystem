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
    public class RoomService : IManager<Room>
    {
        private readonly RoomRepository _roomRepository;
        public RoomService(RoomRepository repository)
        {
            _roomRepository = repository;
        }
        public void Create(Room entity)
        {

            _roomRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            var room = _roomRepository.GetByID(id);
            if (room.IsDeleted)
            {
                throw new Exception("Aktif olan bir kategori silinemez.");
            }
            _roomRepository.Delete(id);
        }
        public IEnumerable<Room> GetAll()
        {
            return _roomRepository.GetAllWithRoomTypes();
        }

        public Room GetByID(Guid id)
        {
            return _roomRepository.GetByID(id);
        }

        public bool IfEntityExists(Room entity)
        {
            return _roomRepository.IfEntityExists(r => r.Hotel == entity.Hotel);
        }

        public void Update(Room entity)
        {
            if (entity != null)
            {
                _roomRepository.Update(entity);
            }
        }
    }
}
