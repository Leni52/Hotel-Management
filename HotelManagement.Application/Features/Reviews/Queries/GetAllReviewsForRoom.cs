using AutoMapper;
using HotelManagement.Application.DTO.Review.Response;
using HotelManagement.Domain.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Application.Features.Reviews.Queries
{
    public class GetAllReviewsForRoom : IRequest<IEnumerable<ReviewResponseModel>>
    {
        public Guid RoomId { get; }
        public GetAllReviewsForRoom(Guid roomId)
        {
            RoomId = roomId;
        }
        public class GetAllReviewsForRoomHandler : IRequestHandler<GetAllReviewsForRoom, IEnumerable<ReviewResponseModel>>
        {
            private readonly HotelDbContext _context;
            private readonly IMapper _mapper;
            public GetAllReviewsForRoomHandler(HotelDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<IEnumerable<ReviewResponseModel>> Handle(GetAllReviewsForRoom request, CancellationToken cancellationToken)
            {
                var reviewsList = await _context.Reviews.Where(r => r.RoomId == request.RoomId).ToListAsync();
                var reviewsResponse = _mapper.Map<IEnumerable<ReviewResponseModel>>(reviewsList);
                if (!reviewsResponse.Any())
                {

                }
                return reviewsResponse;
            }
        }
    }
}
