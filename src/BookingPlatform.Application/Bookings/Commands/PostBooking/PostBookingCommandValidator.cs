using FluentValidation;
using BookingPlatform.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BookingPlatform.Application.Bookings.Commands.PostBooking
{
    public class PostBookingCommandValidator : AbstractValidator<PostBookingCommand>
    {
        private readonly IApplicationDbContext _context;

        public PostBookingCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.UserEmail).NotNull().NotEmpty().WithMessage("User email is required.").EmailAddress().WithMessage("Should be in email format.");

            RuleFor(x => x).MustAsync(IsRoomIdValid).WithMessage("Room id is not valid.");

            RuleFor(x => x).Must(IsCapacityNotEmpty).WithMessage("Number of people should be greater than zero.")
                .MustAsync(EnoughCapacity).WithMessage("Room does not have enough capacity");

            RuleFor(x => x.UtcDateFrom).NotNull().NotEmpty().GreaterThan(DateTime.UtcNow).WithMessage("Date From should be greater than current date.");

            RuleFor(x => x).MustAsync(ValidDateFrom).WithMessage("Date To should be greater than Date From.")
                .MustAsync(AreDatesAvailable).WithMessage("Dates are not available.");
        }

        public async Task<bool> IsRoomIdValid(PostBookingCommand request, CancellationToken cancellationToken)
        {
            var isValid = false;

            var room = await _context.Rooms
                .Where(x => x.Id == request.RoomId)
                .FirstOrDefaultAsync();

            if (room != null && room.Id > 0)
                return true;

            return isValid;
        }

        public bool IsCapacityNotEmpty(PostBookingCommand request)
        {
            bool isValid = false;

            if (request.NumberOfPeople != null && request.NumberOfPeople > 0)
                return true;

            return isValid;
        }

        public async Task<bool> EnoughCapacity(PostBookingCommand request, CancellationToken cancellationToken)
        {
            var isValid = false;

            var room = await _context.Rooms
                .Where(x => x.Id == request.RoomId)
                .FirstOrDefaultAsync();

            if(room == null || (room != null && request.NumberOfPeople <= room?.Capacity))
                return true;

            return isValid;
        }

        public async Task<bool> ValidDateFrom(PostBookingCommand request, CancellationToken cancellationToken)
        {
            bool isValid = false;

            if (request.UtcDateFrom != null && request.UtcDateTo > request.UtcDateFrom)
                return true;

            return isValid;
        }

        public async Task<bool> AreDatesAvailable(PostBookingCommand request, CancellationToken cancellationToken)
        {
            var hasConflict = await _context.Bookings
                .AnyAsync(b => b.RoomId == request.RoomId &&
                ((request.UtcDateFrom >= b.UtcDateFrom && request.UtcDateFrom <= b.UtcDateTo) || (request.UtcDateTo >= b.UtcDateFrom && request.UtcDateTo <= b.UtcDateTo)));

            var bookings = _context.Bookings;

            return !hasConflict;
        }
    }
}
