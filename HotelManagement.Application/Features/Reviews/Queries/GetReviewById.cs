using AutoMapper;
using HotelManagement.Application.DTO.Review.Response;
using HotelManagement.Domain.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Application.Features.Reviews.Queries
{
    public class GetReviewById : IRequest<ReviewResponseModel>
    {
        public Guid ReviewId { get; }
        public GetReviewById(Guid reviewId)
        {
            ReviewId = reviewId;
        }

        public class GetRoomByIdHandler : IRequestHandler<GetReviewById, ReviewResponseModel>
        {
            private readonly HotelDbContext _context;
            private readonly IMapper _mapper;

            public GetRoomByIdHandler(HotelDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ReviewResponseModel> Handle(GetReviewById request, CancellationToken cancellationToken)
            {
                var review = _context.Reviews.Where(r => r.Id == request.ReviewId).FirstOrDefault();
                if (review == null)
                {

                }
                var reviewResponse = _mapper.Map<ReviewResponseModel>(review);
                return reviewResponse;
            }
        }
    }
}
