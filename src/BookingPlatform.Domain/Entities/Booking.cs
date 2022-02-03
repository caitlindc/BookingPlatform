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

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public string UserEmail { get; set; }

        public DateTime BookedDate { get; set; }

        public Room Room { get; set; }
    }
}
