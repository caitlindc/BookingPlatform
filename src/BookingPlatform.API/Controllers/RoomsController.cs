using BookingPlatform.Application.Rooms.Queries.GetRooms;
using Microsoft.AspNetCore.Mvc;

namespace BookingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<GetRoomsResponse>> Get()
        {
            return await Mediator.Send(new GetRoomsQuery());
        }
    }
}
