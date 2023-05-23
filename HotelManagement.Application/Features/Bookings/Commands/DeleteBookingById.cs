using ExceptionHandling.Exceptions;
using HotelManagement.Domain.Data;
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
        public DeleteBookingById(Guid bookingId, Guid roomId)
        {
            BookingId = bookingId;
            RoomId = roomId;
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
                var room = await _context.Rooms
                    .Include(r => r.Bookings)
                    .FirstOrDefaultAsync(r => r.Id == request.RoomId);
                if (room == null)
                {
                    throw new ItemDoesNotExistException();
                }
                var booking =  room.Bookings.FirstOrDefault(b => b.Id == request.BookingId);
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
