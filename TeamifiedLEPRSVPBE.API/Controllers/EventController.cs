using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamifiedLEPRSVPBE.Application.Dtos;
using TeamifiedLEPRSVPBE.Application.Interfaces;

namespace TeamifiedLEPRSVPBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("GetEvents")]
        public async Task<IActionResult> GetEvents(int size, int page)
        {
            var toReturn = await _eventService.GetAllEventsAsync(size, page);
            return Ok(toReturn);
        }

        [HttpGet("GetEventsByUserAsync/{user}")]
        public async Task<IActionResult> GetEventByUserAsync([FromRoute] string user,int size, int page)
        {
            return Ok(await _eventService.GetAllEventsByUserAsync(user,size, page));
        }

        [HttpGet("GetEventsByIdAsync/{id}")]
        public async Task<IActionResult> GetEventByIdAsync([FromRoute] int id)
        {
            return Ok(await _eventService.GetEventByIdAsync(id));
        }

        [HttpPost("AddEvent")]
        public async Task<IActionResult> AddEventAsync([FromBody] CreateEventDto eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _eventService.AddEventAsync(eventDto);
            return Ok();
        }

        [HttpDelete("DeleteEvent/{id}")]
        public async Task<IActionResult> DeleteEventAsync([FromRoute] int id)
        {
            try
            {
                await _eventService.DeleteEventAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(ex.Message);
            }
       
        }
        [HttpPut("UpdateEvent")]
        public async Task<IActionResult> UpdateEventAsync([FromBody] UpdateEventDto eventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _eventService.UpdateEventAsync(eventDto);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(ex.Message);
            }
        
        }

        [HttpPatch("ProcessReservation")]
        public async Task<IActionResult> ProcessReservation([FromBody] ReservationRequestDto reservationRequestDto)
        {
            try
            {
                await _eventService.ProcessReservationAsync(reservationRequestDto.EventId, reservationRequestDto.Username);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(ex.Message);
            }

       
        }
    }
}

