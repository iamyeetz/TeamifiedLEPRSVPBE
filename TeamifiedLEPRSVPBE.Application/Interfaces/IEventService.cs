using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamifiedLEPRSVPBE.Application.Dtos;
using TeamifiedLEPRSVPBE.Core.Entities;

namespace TeamifiedLEPRSVPBE.Application.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<ResponseEventDto>> GetAllEventsAsync(int size, int page);
        Task<IEnumerable<ResponseEventDto>> GetAllEventsByUserAsync(string user, int size, int page);
        Task<ResponseEventDto> GetEventByIdAsync(int id);
        Task AddEventAsync(CreateEventDto eventDto);
        Task<ResponseEventDto> UpdateEventAsync(UpdateEventDto item);
        Task DeleteEventAsync(int id);
        Task ProcessReservationAsync(int id,string username);
    }
}
