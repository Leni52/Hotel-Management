using ExceptionHandling.Exceptions;
using HotelManagement.Domain.Data;
using HotelManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Application.Features.Bookings.Commands
{
    public class DeleteBookingById : IRequest<Guid>
    {
        public Guid BookingId { get; set; }
        public Guid RoomId { get; set; }
        public DeleteBookingById(Guid bookingId)
        {
            BookingId = bookingId;
        }
        public class DeleteBookingByIdHandler : IRequestHandler<DeleteBookingById, Guid>
        {
            private readonly HotelDbContext _context;
            public DeleteBookingByIdHandler(HotelDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(DeleteBookingById request, CancellationToken cancellationToken)
            {
                var booking = await _context.Bookings.Where(booking => booking.Id == request.BookingId).FirstOrDefaultAsync();
                if (booking == null)
                {
                    throw new ItemDoesNotExistException();
                }
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
                return booking.Id;
            }
        }
    }
}
