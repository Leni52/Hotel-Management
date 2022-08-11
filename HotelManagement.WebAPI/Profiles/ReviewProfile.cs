using AutoMapper;
using HotelManagement.Application.DTO.Review.Response;
using HotelManagement.Application.DTO.Reviews.Request;
using HotelManagement.Domain.Entities;

namespace HotelManagement.WebAPI.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewRequestModel>()
                .ReverseMap();
            CreateMap<Review, ReviewResponseModel>()
                .ReverseMap();
        }
    }
}
