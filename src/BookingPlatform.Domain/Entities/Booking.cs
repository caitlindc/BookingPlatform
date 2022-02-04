using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingPlatform.Domain.Entities
{
    public class Booking
    {
        public long Id { get; set; }

        public long RoomId { get; set; }

        public int NumberOfPeople { get; set; }

        public DateTime UtcDateFrom { get; set; }

        public DateTime UtcDateTo { get; set; }

        public string UserEmail { get; set; }

        public DateTime UtcBookedDate { get; set; }

        public Room Room { get; set; }
    }
}
