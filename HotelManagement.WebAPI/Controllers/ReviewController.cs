using HotelManagement.Application.DTO.Review.Response;
using HotelManagement.Application.DTO.Reviews.Request;
using HotelManagement.Application.Features.Reviews.Commands;
using HotelManagement.Application.Features.Reviews.Queries;
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
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<IEnumerable<ReviewResponseModel>>> GetAllReviews()
        {
            var query = new GetAllReviews();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("Room/{roomId:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<IEnumerable<ReviewResponseModel>>> GetAllReviewsForRoom(Guid roomId)
        {
            var query = new GetAllReviewsForRoom(roomId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Review>> CreateRoom(ReviewRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var command = new CreateReview(request.Content,
                request.Title,
                request.RoomId);

            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpGet("{reviewId:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ReviewResponseModel>> GetById(Guid reviewId)
        {

            var query = new GetReviewById(reviewId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{reviewId}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> DeleteReview(Guid reviewId)
        {
            var command = new DeleteReviewById(reviewId);
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPut("reviewId")]
        [ProducesResponseType(403)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateReview(Guid reviewId, ReviewRequestUpdateModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var command = new UpdateReview(
                request.Content,
                request.Title,
                reviewId
                );
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

