using AutoMapper;
using ExceptionHandling.Exceptions;
using HotelManagement.Application.DTO.Room.Response;
using HotelManagement.Domain.Data;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Application.Features.Rooms.Queries
{
    public class GetRoomById : IRequest<RoomResponseModel>
    {
        public Guid RoomId { get; }
        public GetRoomById(Guid roomId)
        {
            RoomId = roomId;
        }

        public class GetRoomByIdHandler : IRequestHandler<GetRoomById, RoomResponseModel>
        {
            private readonly HotelDbContext _context;
            private readonly IMapper _mapper;

            public GetRoomByIdHandler(HotelDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<RoomResponseModel> Handle(GetRoomById request, CancellationToken cancellationToken)
            {
                var room = _context.Rooms.Where(r => r.Id == request.RoomId).FirstOrDefault();
                if (room == null)
                {
                    throw new ItemDoesNotExistException();
                }
                var roomResponse = _mapper.Map<RoomResponseModel>(room);
                return roomResponse;
            }
        }
    }
}
