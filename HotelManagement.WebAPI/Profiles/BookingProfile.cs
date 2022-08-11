using AutoMapper;
using HotelManagement.Application.DTO.Booking.Response;
using HotelManagement.Application.DTO.Bookings.Request;
using HotelManagement.Domain.Entities;

namespace HotelManagement.WebAPI.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingRequestModel>()
                .ReverseMap();
            CreateMap<Booking, BookingResponseModel>()
                .ReverseMap();
        }
    }
}
