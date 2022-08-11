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
    public class GetAllReviews : IRequest<IEnumerable<ReviewResponseModel>>
    {
        public class GetAllReviewsHandler : IRequestHandler<GetAllReviews, IEnumerable<ReviewResponseModel>>
        {
            private readonly HotelDbContext _context;
            private readonly IMapper _mapper;

            public GetAllReviewsHandler(HotelDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ReviewResponseModel>> Handle(GetAllReviews request, CancellationToken cancellationToken)
            {
                var reviewsList = await _context.Reviews.ToListAsync();
                var reviewsResponse = _mapper.Map<IEnumerable<ReviewResponseModel>>(reviewsList);
                if (!reviewsResponse.Any())
                {

                }
                return reviewsResponse;
            }
        }
    }
}
