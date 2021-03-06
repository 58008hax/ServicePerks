using System;
using System.ComponentModel.DataAnnotations;

namespace ServicePerks.Entities
{
    public class Events
    {
        public string Id { get; set; }
        public string EventName { get; set; }
        public int EventPoints { get; set; }
        public DateTime EventDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string EventLocation { get; set; }
        public float EventLat { get; set; }
        public float EventLong { get; set; }
        public string EventDescription { get; set; }
        public int Registered { get; set; }
    }
}