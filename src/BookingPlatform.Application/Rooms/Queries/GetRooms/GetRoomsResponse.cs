

namespace BookingPlatform.Application.Rooms.Queries.GetRooms
{
    public class GetRoomsResponse
    {
        public GetRoomsResponse()
        {
            Rooms = new List<RoomDto>();
        }

        public int Count { get; set; }

        public IList<RoomDto> Rooms { get; set; }
    }
}
