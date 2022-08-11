using HotelManagement.Application.DTO.Room.Response;
using HotelManagement.Application.DTO.Rooms.Request;
using HotelManagement.Application.Features.Rooms.Commands;
using HotelManagement.Application.Features.Rooms.Queries;
using HotelManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<IEnumerable<RoomResponseModel>>> GetAllRooms()
        {
            var query = new GetAllRooms();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Room>> CreateRoom(RoomRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var command = new CreateRoom(request.Number,
                request.RoomType,
                request.Price,
                 request.Available,
                request.Description,
                request.MaximumGuests);
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpGet("{roomId:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<RoomResponseModel>> GetById(Guid roomId)
        {

            var query = new GetRoomById(roomId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{roomId}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> DeleteRoom(Guid roomId)
        {
            var command = new DeleteRoomById(roomId);
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPut("roomId")]
        [ProducesResponseType(403)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateRoom(Guid roomId, RoomRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var command = new UpdateRoom(
                roomId,
                request.Number,
                request.RoomType,
                request.Price,
                request.Available,
                request.Description,
                request.MaximumGuests
                );
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }


}
