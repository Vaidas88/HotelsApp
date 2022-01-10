using HotelsApp.Dtos;
using HotelsApp.Models;
using HotelsApp.Repositories;
using System.Collections.Generic;

namespace HotelsApp.Services
{
    public class CityService
    {
        private readonly CityRepo _cityRepo;

        public CityService(CityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public List<CityDto> GetAll()
        {
            List<CityDto> citiesDto = new List<CityDto>();
            List<City> cities = _cityRepo.GetAll();

            cities.ForEach(city => citiesDto.Add(new CityDto()
            {
                Id = city.Id,
                Name = city.Name
            }
            ));

            return citiesDto;
        }

        public CityDto GetSingle(int id)
        {
            City city = _cityRepo.GetSingle(id);

            return new CityDto()
            {
                Id = city.Id,
                Name = city.Name
            };
        }

        public void Create(CityDto city)
        {
            _cityRepo.Add(new City()
            {
                Id = city.Id,
                Name = city.Name
            });

            _cityRepo.SaveChanges();
        }
    }
}
