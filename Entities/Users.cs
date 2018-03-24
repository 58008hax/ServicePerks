using System;
using System.ComponentModel.DataAnnotations;

namespace ServicePerks.Entities
{
    public class Users
    {
        [Key]
        public string Id {get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Type { get; set; }
        public int points { get; set; }
    }
}