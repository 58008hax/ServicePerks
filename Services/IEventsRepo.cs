using System;
using System.Collections.Generic;
using ServicePerks.Entities;

namespace ServicePerks.Services
{
    public interface IEventsRepo
    {
        void AddEvent(Events e);
        bool EventExists(string id);
        void DeleteEvent(Events e);
        Events GetEvent(string id);
        IEnumerable<Events> GetAllEvents();
        void UpdateEvent(string id, Events e);
        bool Save();
    }
}