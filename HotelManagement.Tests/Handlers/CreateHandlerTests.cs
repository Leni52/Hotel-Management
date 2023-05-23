using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HotelManagement.Application.Features.Rooms.Commands;
using HotelManagement.Domain.Data;
using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Enums;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using static HotelManagement.Application.Features.Rooms.Commands.CreateRoom;

namespace HotelManagement.Tests.Handlers
{
    public class CreateRoomHandlerTests
    {
        private readonly Mock<IHotelDbContext> _dbContextMock;
        private readonly CreateRoomHandler _handler;

        public CreateRoomHandlerTests()
        {
            _dbContextMock = new Mock<IHotelDbContext>();
            _dbContextMock.Setup(c => c.Rooms).Returns(CreateMockRoomsDbSet());

            var mapperMock = new Mock<IMapper>();

            _handler = new CreateRoomHandler(_dbContextMock.Object, mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsRoomRequestModel()
        {
            // Arrange
            var request = new CreateRoom(1, RoomType.Luxury, 100.0f, true, "Test Room", 2);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            _dbContextMock.Verify(c => c.Rooms.AddAsync(It.IsAny<Room>(), It.IsAny<CancellationToken>()), Times.Once);
            _dbContextMock.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

        }

        private DbSet<Room> CreateMockRoomsDbSet()
        {
            var roomData = new List<Room>
            {
                new Room { Number = 1, RoomType = RoomType.Luxury, Price = 100.0f, Available = true, Description = "Test Room", MaximumGuests = 2 },

            };

            var queryableData = roomData.AsQueryable();
            var dbSetMock = new Mock<DbSet<Room>>();

            dbSetMock.As<IQueryable<Room>>().Setup(m => m.Provider).Returns(queryableData.Provider);
            dbSetMock.As<IQueryable<Room>>().Setup(m => m.Expression).Returns(queryableData.Expression);
            dbSetMock.As<IQueryable<Room>>().Setup(m => m.ElementType).Returns(queryableData.ElementType);
            dbSetMock.As<IQueryable<Room>>().Setup(m => m.GetEnumerator()).Returns(() => queryableData.GetEnumerator());

            return dbSetMock.Object;
        }
    }
}
