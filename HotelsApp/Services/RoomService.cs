using HotelsApp.Models;
using HotelsApp.Repositories;
using System.Collections.Generic;

namespace HotelsApp.Services
{
    public class RoomService
    {
        private readonly RoomRepo _roomRepo;

        public RoomService(RoomRepo roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public void Book(int id)
        {
            Room room = _roomRepo.GetSingle(id);

            room.IsBooked = true;

            _roomRepo.Update(room);

            _roomRepo.SaveChanges();
        }

        public List<Room> GetAll()
        {
            return _roomRepo.GetAll();
        }
    }
}
