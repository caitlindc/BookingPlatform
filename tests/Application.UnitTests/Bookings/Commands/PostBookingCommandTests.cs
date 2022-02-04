using BookingPlatform.Application.Bookings.Commands.PostBooking;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Bookings.Commands
{
    public class PostBookingCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_PostBooking()
        {
            var command = new PostBookingCommand
            {
                RoomId = 1,
                NumberOfPeople = 1,
                UtcDateFrom = Convert.ToDateTime("10/02/2022"),
                UtcDateTo = Convert.ToDateTime("15/02/2022"),
                UserEmail = "user@gmail.com"
            };

            var handler = new PostBookingCommand.PostBookingCommandHandler(Context, Mapper);

            var result = await handler.Handle(command, CancellationToken.None);

            result.ShouldBe(true);
            
        }
    }
}
