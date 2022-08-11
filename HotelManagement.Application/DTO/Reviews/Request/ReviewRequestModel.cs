using System;

namespace HotelManagement.Application.DTO.Review.Request
{
    public class ReviewRequestModel
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public Guid RoomId { get; set; }
    }
}
