using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Events.Models;
using Events.Data;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Logging;

namespace Events.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly EventDataInterface eventData;
        private readonly ILogger<EventController> logger;

        public EventController(EventDataInterface eventdata, ILogger<EventController> Logger) 
        {
            eventData = eventdata;
            logger = Logger;
        }

        [HttpGet]
        public IActionResult RetrieveEvents()
        {
            logger.LogInformation("Retrieving Events");
            List<Event> events=eventData.RetrieveAllEvents();
            return Ok(events);
        }
        [HttpGet("{id}")]
        public IActionResult RetrieveEvent(int id) 
        {
            logger.LogInformation("Retrieving Event using id : {Id}",id);
            Event _event = eventData.RetrieveEvent(id);
            if(_event==null)
            {
                return NotFound();
            }
            return Ok(_event);
        }
        [HttpPost]
        public IActionResult AddEvent([FromBody]  Event _event) 
        {
            logger.LogInformation("Adding Event using event : {Event}", _event);
            eventData.AddEvent(_event);
            return Ok(eventData.RetrieveAllEvents());
        }
        [HttpPut]
        public IActionResult UpdateEvent([FromBody] Event _event) 
        {
            
            logger.LogInformation("Updating Event using event : {Event}", _event);
            if (_event == null)
            {
                logger.LogWarning("Event is null");
                return BadRequest();
            }
            var ret = eventData.RetrieveEvent(_event.Id);
            if (ret != null)
            {
                eventData.UpdateEvent(_event);
                return NoContent();
            }
            logger.LogWarning("Id is not found");
            return NotFound();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id) 
        {
            logger.LogInformation("Deleting Event using id : {Id}", id);
            var _event = eventData.RetrieveEvent(id);
            if (_event != null)
            {
               eventData.DeleteEvent(id);
                return NoContent();
            }
            logger.LogWarning("Id is not found");
            return NotFound();
        }


    }
}
