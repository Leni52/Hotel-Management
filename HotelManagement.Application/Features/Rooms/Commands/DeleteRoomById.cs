using HotelManagement.Domain.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Application.Features.Rooms.Commands
{
    public class DeleteRoomById : IRequest<Guid>
    {
        public Guid RoomId { get; set; }
        public DeleteRoomById(Guid roomId)
        {
            RoomId = roomId;
        }
        public class DeleteRoomByIdHandler : IRequestHandler<DeleteRoomById, Guid>
        {
            private readonly HotelDbContext _context;
            public DeleteRoomByIdHandler(HotelDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(DeleteRoomById request, CancellationToken cancellationToken)
            {
                var room = await _context.Rooms.Where(room => room.Id == request.RoomId).FirstOrDefaultAsync();
                if (room == null)
                {

                }
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
                return room.Id;


            }
        }
    }
}
