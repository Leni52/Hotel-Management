using AutoMapper;
using HotelManagement.Application.DTO.Room.Response;
using HotelManagement.Application.DTO.Rooms.Request;
using HotelManagement.Domain.Entities;

namespace HotelManagement.WebAPI.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomRequestModel>();
            CreateMap<Room, RoomResponseModel>();
            CreateMap<RoomRequestModel, Room>();
            CreateMap<RoomResponseModel, Room>();
        }
    }
}
