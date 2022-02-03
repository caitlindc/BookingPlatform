using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingPlatform.Domain.Entities
{
    public class RoomImage
    {
        public long Id { get; set; }

        public long RoomId { get; set; }

        public byte[] Image { get; set; }

        public Room Room { get; set; }
    }
}
