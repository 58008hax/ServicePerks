using System;
using System.ComponentModel.DataAnnotations;

namespace ServicePerks.Entities
{
    public class Users
    {
        public string Id {get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Type { get; set; }
        public int TotalPoints {get; set; }
        public int PointsAvailable { get; set; }
        public int Saved { get; set; }
    }
}