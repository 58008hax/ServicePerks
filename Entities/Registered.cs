using System;
using System.ComponentModel.DataAnnotations;

namespace ServicePerks.Entities
{
    public class Registered
    {
        public string Id { get; set; }
        public string EventCode { get; set; }
        public string UserEmail { get; set; }
        public bool Attended { get; set; }
    }
}