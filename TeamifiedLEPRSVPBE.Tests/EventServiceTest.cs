
using Xunit;
using Moq;

using TeamifiedLEPRSVPBE.Application.Dtos;
using TeamifiedLEPRSVPBE.Application.Services;
using TeamifiedLEPRSVPBE.Core.Entities;
using TeamifiedLEPRSVPBE.Core.Interfaces;

namespace TeamifiedLEPRSVPBE.Tests
{
    public class EventServiceTests
    {
        private readonly Mock<IEventRepository> _mockRepo;
        private readonly EventService _service;

        public EventServiceTests()
        {
            _mockRepo = new Mock<IEventRepository>();
            _service = new EventService(_mockRepo.Object);
        }

        [Fact]
        public async Task AddEvent_ShouldCallRepository()
        {
            var dto = new CreateEventDto { EventName = "Test Event",EventDate = "Mon Jul 14 2025 18:50:00 GMT+0800 (Philippine Standard Time)" };
            await _service.AddEventAsync(dto);
            _mockRepo.Verify(r => r.AddEventAsync(It.IsAny<Event>()), Times.Once);
        }

        [Fact]
        public async Task DeleteEvent_ShouldCallRepository()
        {
            _mockRepo.Setup(r => r.GetEventByIdAsync(1)).ReturnsAsync(new Event { EventId = 1 });
            await _service.DeleteEventAsync(1);
            _mockRepo.Verify(r => r.DeleteEventAsync(1), Times.Once);
        }

        [Fact]
        public async Task GetAllEventsAsync_ShouldReturnDtos()
        {
            var events = new List<Event> { new Event { EventName = "Sample" } };
            _mockRepo.Setup(r => r.GetAllEventsAsync(10, 1)).ReturnsAsync(events);

            var result = await _service.GetAllEventsAsync(10, 1);

            Assert.Single(result);
            Assert.Equal("Sample", result.First().EventName);
        }

        [Fact]
        public async Task GetAllEventsByUserAsync_ShouldReturnDtos()
        {
            var events = new List<Event> { new Event { CreatedBy = "user1" } };
            _mockRepo.Setup(r => r.GetAllEventsByUserAsync("user1", 10, 1)).ReturnsAsync(events);

            var result = await _service.GetAllEventsByUserAsync("user1", 10, 1);

            Assert.Single(result);
            Assert.Equal("user1", result.First().CreatedBy);
        }

        [Fact]
        public async Task GetEventByIdAsync_ShouldReturnDto()
        {
            var ev = new Event { EventId = 1, EventName = "Details" };
            _mockRepo.Setup(r => r.GetEventByIdAsync(1)).ReturnsAsync(ev);

            var result = await _service.GetEventByIdAsync(1);

            Assert.Equal(1, result.EventId);
        }

        [Fact]
        public async Task UpdateEventAsync_ShouldReturnDto()
        {
            var updateDto = new UpdateEventDto { EventId = 1, EventName = "Updated", EventDate = "Mon Jul 14 2025 18:50:00 GMT+0800 (Philippine Standard Time)" };
            _mockRepo.Setup(r => r.GetEventByIdAsync(1)).ReturnsAsync(new Event { EventId = 1, EventName = "EventName" });
            _mockRepo.Setup(r => r.UpdateEventAsync(It.IsAny<Event>())).ReturnsAsync(new Event { EventId = 1, EventName = "Updated" });

            var result = await _service.UpdateEventAsync(updateDto);

            Assert.Equal("Updated", result.EventName);
        }

        [Fact]
        public async Task ProcessReservationAsync_ShouldCallRepository()
        {
            _mockRepo.Setup(r => r.GetEventByIdAsync(1)).ReturnsAsync(new Event { EventId = 1 });
            await _service.ProcessReservationAsync(1, "user1");
            _mockRepo.Verify(r => r.ProcessReservationAsync(1, "user1"), Times.Once);
        }
    }
}
