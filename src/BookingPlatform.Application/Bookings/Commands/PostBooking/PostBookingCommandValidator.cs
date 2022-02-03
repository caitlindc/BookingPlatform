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

            RuleFor(x => x.RoomId).NotNull().NotEqual(0).WithMessage("Room id required.");

            RuleFor(x => x).Must(IsCapacityNotEmpty).WithMessage("Number of people should be greater than zero.")
                .MustAsync(EnoughCapacity).WithMessage("Room does not have enough capacity");

            RuleFor(x => x.DateFrom).NotNull().NotEmpty().GreaterThan(DateTime.UtcNow).WithMessage("Date From should be greater than current date.");

            RuleFor(x => x).MustAsync(ValidDateFrom).WithMessage("Date To should be greater than Date From.")
                .MustAsync(AreDatesAvailable).WithMessage("Dates are not available.");
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

            var roomCapacity = await _context.Rooms
                .Where(x => x.Id == request.RoomId)
                .FirstOrDefaultAsync();
            
            if(request.NumberOfPeople <= roomCapacity?.Capacity)
                return true;

            return isValid;
        }

        public async Task<bool> ValidDateFrom(PostBookingCommand request, CancellationToken cancellationToken)
        {
            bool isValid = false;

            if (request.DateFrom != null && request.DateFrom > request.DateTo)
                return true;

            return isValid;
        }

        public async Task<bool> AreDatesAvailable(PostBookingCommand request, CancellationToken cancellationToken)
        {
            var hasConflict = await _context.Bookings
                .AnyAsync(b => b.RoomId == request.RoomId &&
                ((b.DateFrom > request.DateFrom && b.DateFrom < request.DateTo) || (b.DateTo > request.DateFrom && b.DateTo < request.DateTo)));

            return !hasConflict;
        }
    }
}
