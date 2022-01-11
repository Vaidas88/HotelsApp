using System.Collections.Generic;

namespace HotelsApp.Dtos
{
    public class RoomDto : EntityDto
    {
        public int RoomNumber { get; set; }

        public int Floor { get; set; }

        public HotelDto Hotel { get; set; }

        public List<CleanerDto> Cleaners { get; set; }

        public bool IsBooked { get; set; }
    }
}
