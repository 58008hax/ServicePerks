using System;
using System.Collections.Generic;
using System.Linq;
using ServicePerks.Entities;

namespace ServicePerks.Services
{
    public class EventsRepo : IEventsRepo
    {
        private ServicePerksDBContext _context;

        public EventsRepo(ServicePerksDBContext context)
        {
            _context = context;
        }

        public void AddEvent(Events e)
        {
            _context.Events.Add(e);
        }

        public bool EventExists(string id)
        {
            return _context.Events.Any(x => x.Id == id);
        }

        public void DeleteEvent(Events e)
        {
            _context.Events.Remove(e);
        }

        public Events GetEvent(string id)
        {
            return _context.Events.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Events> GetAllEvents()
        {
            return _context.Events.OrderBy(x => x.EventDate);
        }

        public void UpdateEvent(string id, Events e)
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
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}