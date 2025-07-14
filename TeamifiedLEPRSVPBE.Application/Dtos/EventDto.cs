using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamifiedLEPRSVPBE.Application.Dtos
{
    public class EventDto
    {

        [Required]
        public string EventName { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int MaxReservationNumber { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
    public class CreateEventDto : EventDto
    {
        [Required]
        public string EventDate { get; set; }
    }
    public class UpdateEventDto : EventDto
    {
        [Required]
        public int EventId { get; set; }
        public string EventDate { get; set; }
    }
    public class ResponseEventDto : EventDto
    {
        public int EventId { get; set; }
        public int CurrentReservations { get; set; }
        public DateOnly EventCompleteDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public List<string> Reservations { get; set; } = new List<string>();

    }

}
