using HotelsApp.Dtos;
using HotelsApp.Models;
using HotelsApp.Repositories;
using System.Collections.Generic;

namespace HotelsApp.Services
{
    public class CityService
    {
        private readonly CityRepo _cityRepo;
        private readonly MapService _mapService;

        public CityService(CityRepo cityRepo, MapService mapService)
        {
            _cityRepo = cityRepo;
            _mapService = mapService;
        }

        public List<CityDto> GetAll()
        {
            List<CityDto> citiesDto = new List<CityDto>();
            List<City> cities = _cityRepo.GetAll();

            cities.ForEach(city => citiesDto.Add(_mapService.CityToDto(city)));

            return citiesDto;
        }

        public CityDto GetSingle(int id)
        {
            return _mapService.CityToDto(_cityRepo.GetSingle(id));
        }

        public void Create(CityDto city)
        {
            _cityRepo.Add(_mapService.DtoToCity(city));

            _cityRepo.SaveChanges();
        }

        public void Edit(CityDto city)
        {
            _cityRepo.Update(_mapService.DtoToCity(city));

            _cityRepo.SaveChanges();
        }

        public void Delete(int id)
        {
            City city = _cityRepo.GetSingle(id);

            _cityRepo.Delete(city);

            _cityRepo.SaveChanges();
        }
    }
}
