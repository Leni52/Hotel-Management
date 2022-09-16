using AutoMapper;
using ExceptionHandling.Exceptions;
using HotelManagement.Application.DTO.Room.Response;
using HotelManagement.Domain.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Application.Features.Rooms.Queries
{
    public class GetAllRooms : IRequest<IEnumerable<RoomResponseModel>>
    {
        public class GetAllRoomsHandler : IRequestHandler<GetAllRooms, IEnumerable<RoomResponseModel>>
        {
            private readonly HotelDbContext _context;
            private readonly IMapper _mapper;

            public GetAllRoomsHandler(HotelDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<RoomResponseModel>> Handle(GetAllRooms request, CancellationToken cancellationToken)
            {
                var roomsList = await _context.Rooms.ToListAsync();
                var roomsResponse = _mapper.Map<IEnumerable<RoomResponseModel>>(roomsList);
                if (!roomsResponse.Any())
                {
                    throw new ItemDoesNotExistException();
                }
                return roomsResponse;
            }
        }
    }
}