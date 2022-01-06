using System.Collections.Generic;

namespace HotelsApp.Models
{
    public class Room : Entity
    {
        public int RoomNumber { get; set; }

        public int Floor { get; set; }

        public Hotel Hotel { get; set; }

        public List<Cleaner> Cleaners { get; set; }

        public bool IsBooked { get; set; }
    }
}
