using HotelsApp.Dtos;
using HotelsApp.Models;
using HotelsApp.Repositories;
using System.Collections.Generic;

namespace HotelsApp.Services
{
    public class CleanerService
    {
        private readonly CleanerRepo _cleanerRepo;
        private readonly MapService _mapService;

        public CleanerService(CleanerRepo cleanerRepo, MapService mapService)
        {
            _cleanerRepo = cleanerRepo;
            _mapService = mapService;
        }

        public List<CleanerDto> GetAll()
        {
            return _mapService.CleanersToDto(_cleanerRepo.GetAll());
        }

        public CleanerDto GetSingle(int id)
        {
            return _mapService.CleanerToDto(_cleanerRepo.GetSingle(id));
        }

        public void Create(CleanerDto cleanerDto)
        {
            var cleaner = _mapService.DtoToCleaner(cleanerDto);

            _cleanerRepo.Add(cleaner);

            _cleanerRepo.SaveChanges();
        }

        public void Edit(CleanerDto cleanerDto)
        {
            var cleaner = _mapService.DtoToCleaner(cleanerDto);

            _cleanerRepo.Update(cleaner);

            _cleanerRepo.SaveChanges();
        }
    }
}
