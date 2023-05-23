using AutoMapper;
using HotelManagement.Application.DTO.Rooms.Request;
using HotelManagement.Domain.Data;
using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Application.Features.Rooms.Commands
{
    public class CreateRoom : IRequest<RoomRequestModel>
    {
        public int Number { get; }
        public RoomType RoomType { get; }
        public float Price { get; }
        public bool Available { get; }
        public string Description { get; }
        public int MaximumGuests { get; }

        public CreateRoom(int number, RoomType roomType, float price, bool available, string description, int maximumGuests)
        {
            Number = number;
            RoomType = roomType;
            Price = price;
            Available = available;
            Description = description;
            MaximumGuests = maximumGuests;
        }
        public class CreateRoomHandler : IRequestHandler<CreateRoom, RoomRequestModel>
        {
            private readonly IHotelDbContext _context;
            private readonly IMapper _mapper;

            public CreateRoomHandler(IHotelDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<RoomRequestModel> Handle(CreateRoom request, CancellationToken cancellationToken)
            {
                var room = new Room()
                {
                    Number = request.Number,
                    RoomType = request.RoomType,
                    Price = request.Price,
                    Available = request.Available,
                    Description = request.Description,
                    MaximumGuests = request.MaximumGuests,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now

                };
                await _context.Rooms.AddAsync(room);
                await _context.SaveChangesAsync();
                var roomResponse = _mapper.Map<RoomRequestModel>(room);
                return roomResponse;
            }

        }
    }
}
