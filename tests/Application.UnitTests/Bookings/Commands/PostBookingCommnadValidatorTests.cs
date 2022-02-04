using BookingPlatform.Application.Bookings.Commands.PostBooking;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Bookings.Commands
{
    public class PostBookingCommnadValidatorTests : CommandTestBase
    {
        [Fact]
        public void PostBooking_AllFieldsAreValid()
        {           
            var command = new PostBookingCommand
            {
                RoomId = 1,
                NumberOfPeople = 1,
                UtcDateFrom = Convert.ToDateTime("10/02/2022"),
                UtcDateTo = Convert.ToDateTime("15/02/2022"),
                UserEmail = "user@gmail.com"
            };

            var validator = new PostBookingCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void PostBooking_InvalidRoomId()
        {
            var command = new PostBookingCommand
            {
                RoomId = 100,
                NumberOfPeople = 1,
                UtcDateFrom = Convert.ToDateTime("20/02/2022"),
                UtcDateTo = Convert.ToDateTime("25/02/2022"),
                UserEmail = "user@gmail.com"
            };

            var validator = new PostBookingCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void PostBooking_NotEnoughCapacity()
        {
            var command = new PostBookingCommand
            {
                RoomId = 1,
                NumberOfPeople =5,
                UtcDateFrom = Convert.ToDateTime("20/02/2022"),
                UtcDateTo = Convert.ToDateTime("25/02/2022"),
                UserEmail = "user@gmail.com"
            };

            var validator = new PostBookingCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void PostBooking_ConflictingDates()
        {
            var command = new PostBookingCommand
            {
                RoomId = 1,
                NumberOfPeople =5,
                UtcDateFrom = Convert.ToDateTime("10/02/2022"),
                UtcDateTo = Convert.ToDateTime("15/02/2022"),
                UserEmail = "user@gmail.com"
            };

            var validator = new PostBookingCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void PostBooking_InvalidDateFrom()
        {
            var command = new PostBookingCommand
            {
                RoomId = 1,
                NumberOfPeople =5,
                UtcDateFrom = DateTime.UtcNow.AddDays(-5),
                UtcDateTo = Convert.ToDateTime("15/02/2022"),
                UserEmail = "user@gmail.com"
            };

            var validator = new PostBookingCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public void PostBooking_InvalidDateTo()
        {
            var command = new PostBookingCommand
            {
                RoomId = 1,
                NumberOfPeople =5,
                UtcDateFrom = DateTime.UtcNow.AddDays(2),
                UtcDateTo = DateTime.UtcNow.AddDays(-1),
                UserEmail = "user@gmail.com"
            };

            var validator = new PostBookingCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
