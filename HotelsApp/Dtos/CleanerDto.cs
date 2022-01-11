using System.Collections.Generic;

namespace HotelsApp.Dtos
{
    public class CleanerDto : EntityDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public CityDto City { get; set; }

        public List<RoomDto> Rooms { get; set; }
    }
}
