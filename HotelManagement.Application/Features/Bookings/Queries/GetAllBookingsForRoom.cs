using AutoMapper;
using ExceptionHandling.Exceptions;
using HotelManagement.Application.DTO.Booking.Response;
using HotelManagement.Domain.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Application.Features.Bookings.Queries
{
    public class GetAllBookingsForRoom : IRequest<IEnumerable<BookingResponseModel>>
    {
        public Guid RoomId { get; }
        public GetAllBookingsForRoom(Guid roomId)
        {
            RoomId = roomId;
        }
        public class GetAllBookingsForRoomHandler : IRequestHandler<GetAllBookingsForRoom, IEnumerable<BookingResponseModel>>
        {
            private readonly HotelDbContext _context;
            private readonly IMapper _mapper;

            public GetAllBookingsForRoomHandler(HotelDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<BookingResponseModel>> Handle(GetAllBookingsForRoom request, CancellationToken cancellationToken)
            {
                var bookingsList = await _context.Bookings.Where(b => b.RoomId == request.RoomId).ToListAsync();
                var bookingResponse = _mapper.Map<IEnumerable<BookingResponseModel>>(bookingsList);
                if (!bookingResponse.Any())
                {
                    throw new ItemDoesNotExistException();
                }
                return bookingResponse;
            }
        }
    }
}
