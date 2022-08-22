using System;

namespace HotelManagement.Application.DTO.Bookings.Request
{
    public class BookingRequestModelUpdate
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberOfGuests { get; set; }
        public float TotalFee { get; set; }
        public string OtherRequests { get; set; }
    }
}
