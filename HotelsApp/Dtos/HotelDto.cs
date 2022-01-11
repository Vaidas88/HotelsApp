using System.Collections.Generic;

namespace HotelsApp.Dtos
{
    public class HotelDto : NamedEntityDto
    {
        public CityDto City { get; set; }

        public string Address { get; set; }

        public int MaxRooms { get; set; }

        public List<RoomDto> Rooms { get; set; }

        public List<CityDto> AvailableCities { get; set; }
    }
}
