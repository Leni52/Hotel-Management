using HotelManagement.Domain.Enums;
using System.Collections.Generic;

namespace HotelManagement.Domain.Entities
{
    public class Room : BaseEntity
    {
        public int Number { get; set; }
        public virtual RoomType RoomType { get; set; }
        public float Price { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }
        public int MaximumGuests { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
    }
}
