using BookingPlatform.Application.Mapping;
using BookingPlatform.Domain.Entities;

namespace BookingPlatform.Application.Bookings.Commands.PostBooking
{
    public class PostBookingRequest :IMap<Booking>
    {
        public long RoomId { get; set; }

        public int NumberOfPeople { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public string UserEmail { get; set; }

        public DateTime BookedDate { get; set; }
    }
}
