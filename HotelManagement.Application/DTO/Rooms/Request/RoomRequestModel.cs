using HotelManagement.Domain.Enums;

namespace HotelManagement.Application.DTO.Rooms.Request
{
    public class RoomRequestModel
    {
        public int Number { get; set; }
        public RoomType RoomType { get; set; }
        public float Price { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }
        public int MaximumGuests { get; set; }
    }
}
