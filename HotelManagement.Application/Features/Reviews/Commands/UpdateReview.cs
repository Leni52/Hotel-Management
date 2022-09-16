using AutoMapper;
using ExceptionHandling.Exceptions;
using HotelManagement.Application.DTO.Review.Response;
using HotelManagement.Domain.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Application.Features.Reviews.Commands
{
    public class UpdateReview : IRequest<ReviewResponseModel>
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public Guid ReviewId { get; set; }

        public UpdateReview(string content, string title, Guid reviewId)
        {
            Content = content;
            Title = title;
            ReviewId = reviewId;
        }

        public class UpdateReviewHandler : IRequestHandler<UpdateReview, ReviewResponseModel>
        {
            private readonly HotelDbContext _context;
            private readonly IMapper _mapper;

            public UpdateReviewHandler(HotelDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ReviewResponseModel> Handle(UpdateReview command, CancellationToken cancellationToken)
            {
                var reviewToUpdate = await _context.Reviews.Where(r => r.Id == command.ReviewId).FirstOrDefaultAsync();
                if (reviewToUpdate == null)
                {
                    throw new ItemDoesNotExistException();
                }
                reviewToUpdate.Title = command.Title;
                reviewToUpdate.Content = command.Content;

                reviewToUpdate.LastModifiedAt = DateTime.Now;

                await _context.SaveChangesAsync();
                var reviewResponse = _mapper.Map<ReviewResponseModel>(reviewToUpdate);
                return reviewResponse;
            }
        }
    }
}
