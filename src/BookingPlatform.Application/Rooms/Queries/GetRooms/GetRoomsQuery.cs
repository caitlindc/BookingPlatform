using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookingPlatform.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookingPlatform.Application.Rooms.Queries.GetRooms
{
    public class GetRoomsQuery : IRequest<GetRoomsResponse>
    {

        public class GetRoomsQueryHandler : IRequestHandler<GetRoomsQuery, GetRoomsResponse>
        {

            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetRoomsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetRoomsResponse> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
            {
                var response = new GetRoomsResponse()
                {
                    Rooms = new List<RoomDto>()
                };

                response.Rooms = await _context.Rooms
                    .ProjectTo<RoomDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                response.Count = response.Rooms.Count;

                return response;
            }
        }
    }
}
