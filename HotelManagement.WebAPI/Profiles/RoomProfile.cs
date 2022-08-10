using AutoMapper;
using HotelManagement.Application.DTO.Room.Request;
using HotelManagement.Application.DTO.Room.Response;
using HotelManagement.Domain.Entities;

namespace HotelManagement.WebAPI.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomRequestModel>()
                .ReverseMap();
            CreateMap<Room, RoomResponseModel>()
                .ReverseMap();
        }
    }
}
