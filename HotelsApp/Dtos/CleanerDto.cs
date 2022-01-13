using HotelsApp.Models;
using System.Collections.Generic;

namespace HotelsApp.Dtos
{
    public class CleanerDto : EntityDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public City City { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
