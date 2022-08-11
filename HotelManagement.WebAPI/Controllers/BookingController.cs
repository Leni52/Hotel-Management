using HotelManagement.Application.DTO.Booking.Response;
using HotelManagement.Application.DTO.Bookings.Request;
using HotelManagement.Application.Features.Bookings.Commands;
using HotelManagement.Application.Features.Bookings.Queries;
using HotelManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<IEnumerable<BookingResponseModel>>> GetAllBookings()
        {
            var query = new GetAllBookings();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> CreateRoom(BookingRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var command = new CreateBooking(
                request.RoomId,
                request.CheckIn,
                request.CheckOut,
                request.NumberOfGuests,
                request.OtherRequests);
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpGet("{bookingId:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BookingResponseModel>> GetById(Guid bookingId)
        {

            var query = new GetBookingById(bookingId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{bookingId}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> DeleteBooking(Guid bookingId)
        {
            var command = new DeleteBookingById(bookingId);
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPut("bookingId")]
        [ProducesResponseType(403)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateBooking(Guid bookingId, Guid roomId, BookingRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var command = new UpdateBooking(
                bookingId,
                roomId,
                request.CheckIn,
                request.CheckOut,
                request.NumberOfGuests,
                request.OtherRequests
                );
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
