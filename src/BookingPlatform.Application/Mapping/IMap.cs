using AutoMapper;

namespace BookingPlatform.Application.Mapping
{
    public interface IMap<T>
    {
        void MapFromEntity(Profile profile) => profile.CreateMap(typeof(T), GetType());

        void MapToEntity(Profile profile) => profile.CreateMap(GetType(), typeof(T));
    }
}
