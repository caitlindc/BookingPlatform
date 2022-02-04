using BookingPlatform.Application.Bookings.Commands.PostBooking;
using Microsoft.AspNetCore.Mvc;

namespace BookingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<bool>> Post(PostBookingCommand request)
        {
            return await Mediator.Send(request);
        }
    }
}
