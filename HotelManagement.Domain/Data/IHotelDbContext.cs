using HotelManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Domain.Data
{
    public interface IHotelDbContext
    {
        DbSet<Room> Rooms { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Booking> Bookings { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }

}
