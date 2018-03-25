using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServicePerks.Entities;

namespace ServicePerks.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly ServicePerksDBContext _context;

        public EventsController(ServicePerksDBContext context)
        {
            _context = context;

            if(_context.Events.Count() == 0)
            {
                _context.Events.Add(new Events { Id="event1"});
                _context.SaveChanges();
            }
        }
        
        [HttpGet]
        public IActionResult GetEvents()
        {
            var e = _context.Events.OrderBy(x => x.EventDate);
            return new JsonResult(e);
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(string id)
        {
            var e = _context.Events.FirstOrDefault(x => x.Id == id);
            return new JsonResult(e);
        }

        [HttpPost]
        public IActionResult CreateEvent(Events e)
        {
            _context.Events.Add(e);
            _context.SaveChanges();
            return new JsonResult(e);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvent(string id, Events e)
        {
            var currEvent = _context.Events.FirstOrDefault(x => x.Id == id);

            currEvent.EventName = e.EventName; 
            currEvent.EventPoints = e.EventPoints;
            currEvent.EventDate = e.EventDate;
            currEvent.EventLocation = e.EventLocation;
            currEvent.EventDescription = e.EventDescription;
            currEvent.Registered = e.Registered;
                
            _context.Events.Update(currEvent);
            _context.SaveChanges();

            return new JsonResult(e);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(Events e)
        {
            _context.Events.Remove(e);
            return new JsonResult(e);
        }
    }
}