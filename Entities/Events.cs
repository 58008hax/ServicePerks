using System;
using System.ComponentModel.DataAnnotations;

namespace ServicePerks.Entities
{
    public class Events
    {
        [Key]
        public string Id { get; set; }

        public string EventName { get; set; }
        public int EventPoints { get; set; }
        public DateTime EventDate { get; set; }
        public int Registered { get; set; }
    }
}