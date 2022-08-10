using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Domain.Entities
{
    public class Review:BaseEntity
    {
        [MaxLength(150)]
        public string Content { get; set; }
        public string Title { get; set; }
        public virtual Room Room { get; set; }
        public Guid RoomId { get; set; }

    }
}
