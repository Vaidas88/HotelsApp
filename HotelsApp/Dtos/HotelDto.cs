using HotelsApp.Models;
using System.Collections.Generic;

namespace HotelsApp.Dtos
{
    public class HotelDto : NamedEntityDto
    {
        public City City { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }

        public int MaxRooms { get; set; }

        public List<Room> Rooms { get; set; }

        public List<CityDto> AvailableCities { get; set; }
    }
}
