using HotelsApp.Dtos;
using HotelsApp.Models;
using HotelsApp.Repositories;
using System.Collections.Generic;

namespace HotelsApp.Services
{
    public class HotelService
    {
        private readonly MapService _mapService;
        private readonly CityService _cityService;
        private readonly HotelRepo _hotelRepo;

        public HotelService(HotelRepo hotelRepo, CityService cityService, MapService mapService)
        {
            _mapService = mapService;
            _cityService = cityService;
            _hotelRepo = hotelRepo;
        }

        public List<HotelDto> GetAll()
        {
            return _mapService.HotelsToDto(_hotelRepo.GetAll());
        }

        public List<HotelDto> GetAvailable()
        {
            return _mapService.HotelsToDto(_hotelRepo.GetAvailable());
        }

        public HotelDto GetSingle(int id)
        {
            return _mapService.HotelToDto(_hotelRepo.GetSingle(id));
        }

        public void Create(HotelDto hotelDto)
        {
            var hotel = _mapService.DtoToHotel(hotelDto);

            _hotelRepo.Add(hotel);

            _hotelRepo.SaveChanges();
        }

        public void Edit(HotelDto hotelDto)
        {
            var hotel = _mapService.DtoToHotel(hotelDto);

            _hotelRepo.Update(hotel);

            _hotelRepo.SaveChanges();
        }

        public void Delete(int id)
        {
            var hotel = _hotelRepo.GetSingle(id);

            _hotelRepo.Delete(hotel);

            _hotelRepo.SaveChanges();
        }
    }
}
