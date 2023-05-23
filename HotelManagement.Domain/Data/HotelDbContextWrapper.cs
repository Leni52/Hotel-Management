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
    public class HotelDbContextWrapper : IHotelDbContext
    {
        private readonly HotelDbContext _context;
        public HotelDbContextWrapper(HotelDbContext context)
        {
            _context = context;

        }

        public DbSet<Room> Rooms
        {
            get => _context.Rooms;
            set => _context.Rooms = value;
        }
        public DbSet<Review> Reviews
        {
            get => _context?.Reviews;
            set => _context.Reviews = value;
        }
        public DbSet<Booking> Bookings
        {
            get => _context.Bookings;
            set => _context.Bookings = value;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
