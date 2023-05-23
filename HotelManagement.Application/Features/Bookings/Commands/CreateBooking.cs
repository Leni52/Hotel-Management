using AutoMapper;
using HotelManagement.Application.DTO.Booking.Response;
using HotelManagement.Application.DTO.Bookings.Request;
using HotelManagement.Domain.Data;
using HotelManagement.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Application.Features.Bookings.Commands
{
    public class CreateBooking : IRequest<BookingResponseModel>
    {
        public Guid RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberOfGuests { get; set; }
        public string OtherRequests { get; set; }

        public CreateBooking(Guid roomId, DateTime checkIn, DateTime checkOut, int numberOfGuests, string otherRequests)
        {
            RoomId = roomId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            NumberOfGuests = numberOfGuests;
            OtherRequests = otherRequests;
        }
        public class CreateBookingHandler : IRequestHandler<CreateBooking, BookingResponseModel>
        {
            private readonly HotelDbContext _context;
            private readonly IMapper _mapper;

            public CreateBookingHandler(HotelDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<BookingResponseModel> Handle(CreateBooking request, CancellationToken cancellationToken)
            {
                var booking = new Booking()
                {
                    RoomId = request.RoomId,
                    CheckIn = request.CheckIn,
                    CheckOut = request.CheckOut,
                    NumberOfGuests = request.NumberOfGuests,
                    OtherRequests = request.OtherRequests,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now
                };
                await _context.Bookings.AddAsync(booking);
                await _context.SaveChangesAsync();
                var bookingResponse = _mapper.Map<BookingResponseModel>(booking);
                return bookingResponse;
            }

        }
    }
}
