using System;

namespace HotelManagement.Application.DTO.Bookings.Request
{
    public class BookingRequestModel
    {
        public Guid RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberOfGuests { get; set; }
        public string OtherRequests { get; set; }

    }
}
