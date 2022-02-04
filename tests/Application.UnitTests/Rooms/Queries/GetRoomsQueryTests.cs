using AutoMapper;
using BookingPlatform.Application.Rooms.Queries.GetRooms;
using BookingPlatform.Infrastructure.Persistence;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Rooms.Queries
{
    [Collection("QueryTests")]
    public class GetRoomsQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRoomsQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_GetRooms()
        {
            var query = new GetRoomsQuery();

            var handler = new GetRoomsQuery.GetRoomsQueryHandler(_context, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<GetRoomsResponse>();

            result.Rooms.ShouldNotBeNull();
            
            result.Rooms.Count.ShouldBe(1);

            var room1 = result.Rooms.Where(x => x.Id == 1).FirstOrDefault();
            room1?.RoomImages.ShouldNotBeNull();
            room1?.RoomImages.Count.ShouldBe(2);
        }
    }
}
