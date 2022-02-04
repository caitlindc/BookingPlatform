using BookingPlatform.Application.Mapping;
using BookingPlatform.Domain.Entities;

namespace BookingPlatform.Application.Rooms.Queries.GetRooms
{
    public class RoomDto : IMap<Room>
    {
        public RoomDto()
        {
            RoomImages = new List<RoomImageDto>();
        }

        public long Id { get; set; }

        public string Title { get; set; }

        public decimal PricePerNightPhp { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public int Capacity { get; set; }

        public bool IsPetFriendly { get; set; }

        public IList<RoomImageDto> RoomImages { get; set; }
    }
}
