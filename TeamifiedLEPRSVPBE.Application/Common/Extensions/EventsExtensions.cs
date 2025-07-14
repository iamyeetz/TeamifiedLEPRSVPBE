using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamifiedLEPRSVPBE.Application.Dtos;
using TeamifiedLEPRSVPBE.Core.Entities;
using TeamifiedLEPRSVPBE.Application.Common.Extensions;

namespace TeamifiedLEPRSVPBE.Application.Common.Extensions
{
    public static class EventsExtensions
    {

        public static Event ToModel(this CreateEventDto eventDto)
        {
            return new Event
            {
                EventName = eventDto.EventName,
                EventDate = eventDto.EventDate.ParseFromJsString(),
                Location = eventDto.Location,
                MaxReservationNumber = eventDto.MaxReservationNumber,
                Description = eventDto.Description,
                CreatedBy = eventDto.CreatedBy,
                Reservations = string.Empty,
            };
        }

        public static Event ToModel(this UpdateEventDto eventDto)
        {
            return new Event
            {
                EventId = eventDto.EventId,
                EventName = eventDto.EventName,
                EventDate = eventDto.EventDate.ParseFromJsString(),
                Location = eventDto.Location,
                MaxReservationNumber = eventDto.MaxReservationNumber,
                Description = eventDto.Description,
                CreatedBy = eventDto.CreatedBy
            };
        }
        public static ResponseEventDto ToDto(this Event eventModel)
        {
            return new ResponseEventDto
            {
                EventId = eventModel.EventId,
                EventName = eventModel.EventName,
                EventCompleteDate = DateOnly.FromDateTime(eventModel.EventDate),
                EventTime = eventModel.EventDate.TimeOfDay,
                Location = eventModel.Location,
                MaxReservationNumber = eventModel.MaxReservationNumber,
                Description = eventModel.Description,
                CreatedBy = eventModel.CreatedBy,
                CurrentReservations = eventModel.CurrentReservations,
                Reservations = string.IsNullOrEmpty(eventModel.Reservations)
                    ? new List<string>()
                    : eventModel.Reservations.Split(',').ToList()
            };
        }
    }
}
