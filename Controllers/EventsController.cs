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
                _context.Events.Add(new Events { Id="event1",
                                                 EventName="Park Cleanup",
                                                 EventPoints=200,
                                                 EventDate= new DateTime(2018, 3, 31),
                                                 StartTime=300,
                                                 EndTime=500,
                                                 EventLocation="Stevens Park, Hoboken, NJ 07030",
                                                 EventDescription="Come help cleanup Stevens Park this coming Saturday from 3 to 5pm!",
                                                 Registered=7});
                _context.Events.Add(new Events { Id="event2",
                                                 EventName="Homeless Shelter",
                                                 EventPoints=100,
                                                 EventDate= new DateTime(2018, 4, 1),
                                                 StartTime=100,
                                                 EndTime=200,
                                                 EventLocation="The Hoboken Shelter, Hoboken, NJ 07030",
                                                 EventDescription="Help make and serve lunch to help support our homeless this Sunday from 1-2pm at the Hoboken Shelter.",
                                                 Registered=3});
                _context.Events.Add(new Events { Id="event3",
                                                 EventName="Boys and Girls Club",
                                                 EventPoints=200,
                                                 EventDate= new DateTime(2018, 4, 3),
                                                 StartTime=600,
                                                 EndTime=800,
                                                 EventLocation="Boys and Girls Club-Hudson County, Hoboken, NJ 07030",
                                                 EventDescription="Come help do whatever it is people do when they volunteer their time at the Boys and Girls Club of Hdson County!",
                                                 Registered=12});
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
            currEvent.StartTime = e.StartTime;
            currEvent.EndTime = e.EndTime;
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