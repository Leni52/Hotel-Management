using AutoMapper;
using HotelManagement.Application.DTO.Room.Response;
using HotelManagement.Domain.Data;
using HotelManagement.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.Application.Features.Rooms.Commands
{
    public class UpdateRoom : IRequest<RoomResponseModel>
    {
        public Guid RoomId { get; }
        public int Number { get; set; }
        public RoomType RoomType { get; set; }
        public float Price { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }
        public int MaximumGuests { get; set; }

        public UpdateRoom(Guid roomId, int number, RoomType roomType, float price, bool available, string description, int maximumGuests)
        {
            RoomId = roomId;
            Number = number;
            RoomType = roomType;
            Price = price;
            Available = available;
            Description = description;
            MaximumGuests = maximumGuests;
        }

        public class UpdateRoomHandler : IRequestHandler<UpdateRoom, RoomResponseModel>
        {
            private readonly HotelDbContext _context;
            private readonly IMapper _mapper;

            public UpdateRoomHandler(HotelDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<RoomResponseModel> Handle(UpdateRoom command, CancellationToken cancellationToken)
            {
                var roomToUpdate = await _context.Rooms.Where(r => r.Id == command.RoomId).FirstOrDefaultAsync();
                if (roomToUpdate == null)
                {

                }
                roomToUpdate.Price = command.Price;
                roomToUpdate.Available = command.Available;
                roomToUpdate.Description = command.Description;
                roomToUpdate.MaximumGuests = command.MaximumGuests;
                roomToUpdate.Number = command.Number;

                roomToUpdate.LastModifiedAt = DateTime.Now;
                await _context.SaveChangesAsync();
                var roomResponse = _mapper.Map<RoomResponseModel>(roomToUpdate);
                return roomResponse;
            }
        }
    }
}
