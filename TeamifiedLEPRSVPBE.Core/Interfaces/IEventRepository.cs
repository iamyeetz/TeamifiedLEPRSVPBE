using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamifiedLEPRSVPBE.Core.Entities;

namespace TeamifiedLEPRSVPBE.Core.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync(int size, int page);
        Task<IEnumerable<Event>> GetAllEventsByUserAsync(string user, int size, int page);
        Task<Event> GetEventByIdAsync(int id);
        Task AddEventAsync(Event item);
        Task<Event> UpdateEventAsync(Event item);
        Task DeleteEventAsync(int id);
        Task ProcessReservationAsync(int id, string username);
    }
}
