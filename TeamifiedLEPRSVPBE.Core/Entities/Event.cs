using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamifiedLEPRSVPBE.Core.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; } 
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int MaxReservationNumber { get; set; }
        public int CurrentReservations { get; set; }
        public string CreatedBy { get; set; }
        public string Reservations { get; set; }
    }
}
