using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamifiedLEPRSVPBE.Application.Dtos;
using TeamifiedLEPRSVPBE.Application.Interfaces;
using TeamifiedLEPRSVPBE.Core.Entities;
using TeamifiedLEPRSVPBE.Core.Interfaces;
using TeamifiedLEPRSVPBE.Application.Common.Extensions;
namespace TeamifiedLEPRSVPBE.Application.Services
{
    public class EventService : IEventService
    {

        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task AddEventAsync(CreateEventDto eventDto)
        {
            await _eventRepository.AddEventAsync(eventDto.ToModel());
        }

        public async Task DeleteEventAsync(int id)
        {
            await CheckIfEventExists(id);
            await _eventRepository.DeleteEventAsync(id);
        }

        public async Task<IEnumerable<ResponseEventDto>> GetAllEventsAsync(int size, int page)
        {
            var toReturn = await _eventRepository.GetAllEventsAsync(size, page);
            return toReturn.Select(x => x.ToDto()).ToList();
        }

        public async Task<IEnumerable<ResponseEventDto>> GetAllEventsByUserAsync(string user, int size, int page)
        {
            var toReturn = await _eventRepository.GetAllEventsByUserAsync(user, size, page);
            return toReturn.Select(x => x.ToDto()).ToList();
        }

        public async Task<ResponseEventDto> GetEventByIdAsync(int id)
        {
            var toReturn = await _eventRepository.GetEventByIdAsync(id);
            return toReturn.ToDto();
        }

        public async Task<ResponseEventDto> UpdateEventAsync(UpdateEventDto item)
        {
            await CheckIfEventExists(item.EventId);
            var toReturn = await _eventRepository.UpdateEventAsync(item.ToModel());

            return toReturn.ToDto();
        }
        public async Task ProcessReservationAsync(int id, string username)
        {
            await CheckIfEventExists(id);
            await _eventRepository.ProcessReservationAsync(id, username);
        }
        private async Task CheckIfEventExists(int id)
        {
            var existingEvent = await _eventRepository.GetEventByIdAsync(id);
            if (existingEvent == null)
            {
                throw new KeyNotFoundException($"Event with ID {id} not found.");
            }

        }
    }
}
