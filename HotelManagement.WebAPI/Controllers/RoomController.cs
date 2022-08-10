using HotelManagement.Application.DTO.Room.Response;
using HotelManagement.Application.Features.Room.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IMediator _mediator;
        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<IEnumerable<RoomResponseModel>>> GetAllArticles()
        {
            var query = new GetAllRooms();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }


}
