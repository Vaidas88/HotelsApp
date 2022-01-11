using HotelsApp.Dtos;
using HotelsApp.Models;
using HotelsApp.Repositories;
using System.Collections.Generic;

namespace HotelsApp.Services
{
    public class HotelService
    {
        private readonly MapService _mapService;
        private readonly HotelRepo _hotelRepo;

        public HotelService(HotelRepo hotelRepo, MapService mapService)
        {
            _mapService = mapService;
            _hotelRepo = hotelRepo;
        }

        public List<HotelDto> GetAll()
        {
            return _mapService.HotelsToDto(_hotelRepo.GetAll());
        }

        public HotelDto GetSingle(int id)
        {
            return _mapService.HotelToDto(_hotelRepo.GetSingle(id));
        }

        public void Create(HotelDto hotel)
        {
            _hotelRepo.Add(_mapService.DtoToHotel(hotel));

            _hotelRepo.SaveChanges();
        }
    }
}
