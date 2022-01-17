using HotelsApp.Dtos;
using HotelsApp.Models;
using System.Collections.Generic;

namespace HotelsApp.Services
{
    public class MapService
    {
        /****** ModelToDto ******/

        public CityDto CityToDto(City city)
        {
            return new CityDto()
            {
                Id = city.Id,
                Name = city.Name
            };
        }

        public RoomDto RoomToDto(Room room)
        {
            return new RoomDto()
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                Floor = room.Floor,
                Hotel = room.Hotel,
                Cleaners = room.Cleaners,
                IsBooked = room.IsBooked
            };
        }

        public HotelDto HotelToDto(Hotel hotel)
        {
            return new HotelDto()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Address = hotel.Address,
                City = hotel.City,
                CityId = hotel.CityId,
                MaxRooms = hotel.MaxRooms,
                Rooms = hotel.Rooms
            };
        }

        public CleanerDto CleanerToDto(Cleaner cleaner)
        {
            return new CleanerDto()
            {
                Id = cleaner.Id,
                FirstName = cleaner.FirstName,
                LastName = cleaner.LastName,
                City = cleaner.City,
                CityId = cleaner.CityId,
                Rooms = cleaner.Rooms
            };
        }

        public List<HotelDto> HotelsToDto(List<Hotel> hotels)
        {
            List<HotelDto> hotelsDto = new List<HotelDto>();

            hotels.ForEach(hotel => hotelsDto.Add(HotelToDto(hotel)));

            return hotelsDto;
        }

        public List<RoomDto> RoomsToDto(List<Room> rooms)
        {
            List<RoomDto> roomsDto = new List<RoomDto>();

            rooms.ForEach(room => roomsDto.Add(RoomToDto(room)));

            return roomsDto;
        }

        public List<CleanerDto> CleanersToDto(List<Cleaner> cleaners)
        {
            List<CleanerDto> cleanersDto = new List<CleanerDto>();

            cleaners.ForEach(cleaner => cleanersDto.Add(CleanerToDto(cleaner)));

            return cleanersDto;
        }

        /****** DtoToModel ******/

        public City DtoToCity(CityDto city)
        {
            return new City()
            {
                Id = city.Id,
                Name = city.Name
            };
        }

        public Room DtoToRoom(RoomDto room)
        {
            return new Room()
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                Floor = room.Floor,
                HotelId = room.Hotel.Id,
                Cleaners = room.Cleaners,
                IsBooked = room.IsBooked
            };
        }

        public Hotel DtoToHotel(HotelDto hotel)
        {
            return new Hotel()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Address = hotel.Address,
                CityId = hotel.City.Id,
                MaxRooms = hotel.MaxRooms,
                Rooms = hotel.Rooms
            };
        }

        public Cleaner DtoToCleaner(CleanerDto cleaner)
        {
            return new Cleaner()
            {
                Id = cleaner.Id,
                FirstName = cleaner.FirstName,
                LastName = cleaner.LastName,
                CityId = cleaner.City.Id,
                Rooms = cleaner.Rooms
            };
        }

        public List<Hotel> DtoToHotels(List<HotelDto> hotelsDto)
        {
            List<Hotel> hotels = new List<Hotel>();

            hotelsDto.ForEach(hotelDto => hotels.Add(DtoToHotel(hotelDto)));

            return hotels;
        }

        public List<Room> DtoToRooms(List<RoomDto> roomsDto)
        {
            List<Room> rooms = new List<Room>();

            roomsDto.ForEach(roomDto => rooms.Add(DtoToRoom(roomDto)));

            return rooms;
        }

        public List<Cleaner> DtoToCleaners(List<CleanerDto> cleanersDto)
        {
            List<Cleaner> cleaners = new List<Cleaner>();

            cleanersDto.ForEach(cleanerDto => cleaners.Add(DtoToCleaner(cleanerDto)));

            return cleaners;
        }
    }
}
