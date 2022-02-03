using AutoMapper;
using BookingPlatform.Application.Common.Interfaces;
using BookingPlatform.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingPlatform.Application.Bookings.Commands.PostBooking
{
    public class PostBookingCommand : IRequest<bool>
    {
        public long RoomId { get; set; }

        public int NumberOfPeople { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public string UserEmail { get; set; }

        public DateTime BookedDate { get; set; }

        public class PostBookingCommandHandler : IRequestHandler<PostBookingCommand, bool>
        {
            private readonly IApplicationDbContext _context;

            private readonly IMapper _mapper;

            public PostBookingCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<bool> Handle(PostBookingCommand request, CancellationToken cancellationToken)
            {
                var entity = new Booking();
                entity = _mapper.Map<Booking>(request);
                _context.Bookings.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
        }
    }
}
