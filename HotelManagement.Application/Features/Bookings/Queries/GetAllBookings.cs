using AutoMapper;
using HotelManagement.Application.DTO.Booking.Response;
using HotelManagement.Domain.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Application.Features.Bookings.Queries
{
    public class GetAllBookings : IRequest<IEnumerable<BookingResponseModel>>
    {
        public class GetAllBookingsHandler : IRequestHandler<GetAllBookings, IEnumerable<BookingResponseModel>>
        {
            private readonly HotelDbContext _context;
            private readonly IMapper _mapper;

            public GetAllBookingsHandler(HotelDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<BookingResponseModel>> Handle(GetAllBookings request, CancellationToken cancellationToken)
            {
                var bookingsList = await _context.Bookings.ToListAsync();
                var bookingResponse = _mapper.Map<IEnumerable<BookingResponseModel>>(bookingsList);
                if (!bookingResponse.Any())
                {

                }
                return bookingResponse;
            }
        }
    }
}
