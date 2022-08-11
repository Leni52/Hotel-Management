using AutoMapper;
using HotelManagement.Application.DTO.Booking.Response;
using HotelManagement.Domain.Data;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Application.Features.Bookings.Queries
{
    public class GetBookingById : IRequest<BookingResponseModel>
    {
        public Guid BookingId { get; }
        public GetBookingById(Guid bookingId)
        {
            BookingId = bookingId;
        }

        public class GetBookingByIdHandler : IRequestHandler<GetBookingById, BookingResponseModel>
        {
            private readonly HotelDbContext _context;
            private readonly IMapper _mapper;

            public GetBookingByIdHandler(HotelDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BookingResponseModel> Handle(GetBookingById request, CancellationToken cancellationToken)
            {
                var booking = _context.Bookings.Where(r => r.Id == request.BookingId).FirstOrDefault();
                if (booking == null)
                {

                }
                var bookingResponse = _mapper.Map<BookingResponseModel>(booking);
                return bookingResponse;
            }
        }
    }
}
