using HotelManagement.Domain.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Application.Features.Reviews.Commands
{
    public class DeleteReviewById : IRequest<Guid>
    {
        public Guid ReviewId { get; set; }
        public DeleteReviewById(Guid reviewId)
        {
            ReviewId = reviewId;
        }
        public class DeleteReviewByIdHandler : IRequestHandler<DeleteReviewById, Guid>
        {
            private readonly HotelDbContext _context;
            public DeleteReviewByIdHandler(HotelDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(DeleteReviewById request, CancellationToken cancellationToken)
            {
                var review = await _context.Reviews.Where(room => room.Id == request.ReviewId).FirstOrDefaultAsync();
                if (review == null)
                {

                }
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
                return review.Id;


            }
        }
    }
}
