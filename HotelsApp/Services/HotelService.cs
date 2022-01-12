using HotelsApp.Dtos;
using HotelsApp.Models;
using HotelsApp.Repositories;
using System.Collections.Generic;

namespace HotelsApp.Services
{
    public class HotelService
    {
        private readonly HotelRepo _hotelRepo;

        public HotelService(HotelRepo hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        public List<Hotel> GetAll()
        {
            return _hotelRepo.GetAll();
        }

        public Hotel GetSingle(int id)
        {
            return _hotelRepo.GetSingle(id);
        }

        public void Create(Hotel hotel)
        {
            _hotelRepo.Add(hotel);

            _hotelRepo.SaveChanges();
        }
    }
}
