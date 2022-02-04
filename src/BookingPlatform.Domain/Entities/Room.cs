using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingPlatform.Domain.Entities
{
    public class Room
    {
        public long Id { get; set; }

        public string Title { get; set; }   

        public decimal PricePerNightPhp { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public int Capacity { get; set; }

        public bool IsPetFriendly { get; set; }

        public virtual List<RoomImage> RoomImages { get; set; }
    }
}
