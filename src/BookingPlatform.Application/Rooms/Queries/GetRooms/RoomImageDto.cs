using AutoMapper;
using BookingPlatform.Application.Mapping;
using BookingPlatform.Domain.Entities;

namespace BookingPlatform.Application.Rooms.Queries.GetRooms
{
    public  class RoomImageDto : IMap<RoomImage>
    {
        public long Id { get; set; }

        public string ImageInBase64 { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RoomImage, RoomImageDto>()
                .ForMember(r => r.ImageInBase64, opt => opt.MapFrom(n => Convert.ToBase64String(n.Image)));
        }
    }
}
