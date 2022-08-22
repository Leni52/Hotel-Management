using AutoMapper;
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

namespace HotelManagement.Application.Features.Bookings.Commands
{
    public class UpdateBooking : IRequest<BookingResponseModel>
    {
        public Guid BookingId { get; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberOfGuests { get; set; }
        public int TotalFee { get; set; }
        public string OtherRequests { get; set; }

        public UpdateBooking(Guid bookingId, DateTime checkIn, DateTime checkOut, int numberOfGuests, int totalFee, string otherRequests)
        {
            BookingId = bookingId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            NumberOfGuests = numberOfGuests;
            TotalFee = totalFee;
            OtherRequests = otherRequests;
        }

        public UpdateBooking(Guid bookingId, DateTime checkIn, DateTime checkOut, int numberOfGuests, string otherRequests)
        {
            BookingId = bookingId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            NumberOfGuests = numberOfGuests;
            OtherRequests = otherRequests;
        }

        public class UpdateBookingHandler : IRequestHandler<UpdateBooking, BookingResponseModel>
        {
            private readonly HotelDbContext _context;
            private readonly IMapper _mapper;

            public UpdateBookingHandler(HotelDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BookingResponseModel> Handle(UpdateBooking command, CancellationToken cancellationToken)
            {
                var bookingToUpdate = await _context.Bookings.Where(r => r.Id == command.BookingId).FirstOrDefaultAsync();
                if (bookingToUpdate == null)
                {

                }
                bookingToUpdate.CheckIn = command.CheckIn;
                bookingToUpdate.CheckOut = command.CheckOut;
                bookingToUpdate.NumberOfGuests = command.NumberOfGuests;
                bookingToUpdate.OtherRequests = command.OtherRequests;
                bookingToUpdate.TotalFee = command.TotalFee;
                bookingToUpdate.LastModifiedAt = DateTime.Now;

                await _context.SaveChangesAsync();
                var bookingResponse = _mapper.Map<BookingResponseModel>(bookingToUpdate);
                return bookingResponse;
            }
        }
    }
}
