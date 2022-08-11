using AutoMapper;
using HotelManagement.Application.DTO.Reviews.Request;
using HotelManagement.Domain.Data;
using HotelManagement.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Application.Features.Reviews.Commands
{
    public class CreateReview : IRequest<ReviewRequestModel>
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public Guid RoomId { get; set; }

        public CreateReview(string content, string title, Guid roomId)
        {
            Content = content;
            Title = title;
            RoomId = roomId;
        }
        public class CreateReviewHandler : IRequestHandler<CreateReview, ReviewRequestModel>
        {
            private readonly HotelDbContext _context;
            private readonly IMapper _mapper;

            public CreateReviewHandler(HotelDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ReviewRequestModel> Handle(CreateReview request, CancellationToken cancellationToken)
            {
                var review = new Review()
                {
                    Content = request.Content,
                    Title = request.Title,
                    RoomId = request.RoomId,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now

                };
                await _context.Reviews.AddAsync(review);
                await _context.SaveChangesAsync();
                var reviewResponse = _mapper.Map<ReviewRequestModel>(review);
                return reviewResponse;
            }

        }
    }
}
