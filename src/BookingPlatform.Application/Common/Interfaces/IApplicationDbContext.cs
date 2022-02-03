using BookingPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingPlatform.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Room> Rooms { get; set; }

        DbSet<Booking> Bookings { get; set; }

        DbSet<RoomImage> RoomImages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
