using System.Collections.Generic;

namespace HotelsApp.Models
{
    public class Cleaner : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public City City { get; set; }

        public int CityId { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
