﻿using System.Collections.Generic;

namespace HotelsApp.Models
{
    public class Hotel : NamedEntity
    {
        public City City { get; set; }

        public string Address { get; set; }

        public int MaxRooms { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
