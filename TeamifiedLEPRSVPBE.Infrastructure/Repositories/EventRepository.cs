using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamifiedLEPRSVPBE.Core.Entities;
using TeamifiedLEPRSVPBE.Core.Interfaces;
using TeamifiedLEPRSVPBE.Infrastructure.Data;

namespace TeamifiedLEPRSVPBE.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {

        private readonly AppDbContext _dbContext;
        public EventRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task AddEventAsync(Event item)
        {
            _dbContext.Events.Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int id)
        {
            var toRemove =  _dbContext.Events.Where(x => x.EventId == id).First();
            _dbContext.Events.Remove(toRemove);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<Event>> GetAllEventsAsync(int size , int page)
        {
            return await _dbContext.Events.Where(x => x.EventDate >= DateTime.UtcNow).Skip((page - 1) * size).Take(size).ToListAsync();
  
        }

        public async Task<IEnumerable<Event>> GetAllEventsByUserAsync(string user,int size,int page)
        {
            return await _dbContext.Events.Where(x => x.CreatedBy == user && x.EventDate >= DateTime.UtcNow).Skip((page - 1) * size).Take(size).ToListAsync();

        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _dbContext.Events.Where( x => x.EventId == id).FirstOrDefaultAsync();
        }

        public async Task<Event> UpdateEventAsync(Event item)
        {
            var existingEvent = await _dbContext.Events.FindAsync(item.EventId);

            // Update properties
            existingEvent.EventName = item.EventName;
            existingEvent.EventDate = item.EventDate;
            existingEvent.Location = item.Location;
            existingEvent.Description = item.Description;
            existingEvent.MaxReservationNumber = item.MaxReservationNumber;
            existingEvent.CreatedBy = item.CreatedBy;

            // Save changes
            await _dbContext.SaveChangesAsync();
            return existingEvent;
        }

        public async Task ProcessReservationAsync(int id,string username)
        {
            var item = await _dbContext.Events.FindAsync(id);
            item.CurrentReservations += 1;
            var reservationsList = item.Reservations.Split(',');
            item.Reservations = string.Join(",", reservationsList.Append(username));
            await _dbContext.SaveChangesAsync();
        }

    }
}
