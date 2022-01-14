using HotelsApp.Dtos;
using HotelsApp.Models;
using HotelsApp.Repositories;
using System.Collections.Generic;

namespace HotelsApp.Services
{
    public class RoomService
    {
        private readonly RoomRepo _roomRepo;
        private readonly MapService _mapService;

        public RoomService(RoomRepo roomRepo, MapService mapService)
        {
            _roomRepo = roomRepo;
            _mapService = mapService;
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

        public RoomDto GetSingle(int id)
        {
            return _mapService.RoomToDto(_roomRepo.GetSingle(id));
        }

        public void Create(RoomDto roomDto)
        {
            var room = _mapService.DtoToRoom(roomDto);

            _roomRepo.Add(room);

            _roomRepo.SaveChanges();
        }

        public void Edit(RoomDto roomDto)
        {
            var room = _mapService.DtoToRoom(roomDto);

            _roomRepo.Update(room);

            _roomRepo.SaveChanges();
        }
    }
}
