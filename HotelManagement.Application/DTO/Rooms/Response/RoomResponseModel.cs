using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Enums;
using System;
using System.Collections.Generic;

namespace HotelManagement.Application.DTO.Room.Response
{
    public class RoomResponseModel
    {
        public Guid Id { get; set; }
        public RoomType RoomType { get; set; }
        public float Price { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }
        public int MaximumGuests { get; set; }
    }
}
