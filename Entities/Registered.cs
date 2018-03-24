using System;
using System.ComponentModel.DataAnnotations;

namespace ServicePerks
{
    public class Registered
    {
        [Key]
        public string Id { get; set; }

        public string EventCode { get; set; }
        public string UserEmail { get; set; }
        public bool Attended { get; set; }
    }
}