using BookingPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingPlatform.Infrastructure.Persistence.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(t => t.RoomId)
                .IsRequired();
            builder.Property(t => t.NumberOfPeople)
                .IsRequired();
            builder.Property(t => t.UserEmail)
                .IsRequired();
            builder.Property(t => t.UserEmail)
                .IsRequired();
            builder.Property(t => t.DateFrom)
                .IsRequired();
            builder.Property(t => t.DateTo)
                .IsRequired();
        }
    }
}
