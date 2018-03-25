using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServicePerks.Entities;

namespace ServicePerks.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ServicePerksDBContext _context;

        public UsersController(ServicePerksDBContext context)
        {
            _context = context;

            if(_context.Users.Count() == 0)
            {
                _context.Users.Add(new Users { Id="user1", 
                                               Email="test@email.com", 
                                               Password="123pass",
                                               FirstName="Matthew",
                                               LastName="Aquiles",
                                               Type=0,
                                               TotalPoints=55000,
                                               PointsAvailable=1200,
                                               Saved=55});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var usersFromRepo = _context.Users.OrderBy(x => x.Email).ToList();
            return new JsonResult(usersFromRepo);
        }

        [HttpGet("{email}")]
        public IActionResult GetUser(string email)
        {
            var userFromRepo = _context.Users.FirstOrDefault(x => x.Email == email);
            return new JsonResult(userFromRepo);
        }

        [HttpPost]
        public IActionResult CreateUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return new JsonResult(user);
        }

        [HttpPut("{email}")]
        public IActionResult UpdateUser(string email, Users user)
        {
            var currUser = _context.Users.FirstOrDefault(x => x.Email == email);

            currUser.Email = user.Email;
            currUser.Password = user.Password;
            currUser.FirstName = user.FirstName;
            currUser.LastName = user.LastName;
            currUser.Type = user.Type;
            currUser.TotalPoints = user.TotalPoints;
            currUser.PointsAvailable = user.PointsAvailable;
            currUser.Saved = user.Saved;

            _context.Users.Update(currUser);
            _context.SaveChanges();

            return new JsonResult(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Users user)
        {
            _context.Users.Remove(user);
            return new JsonResult(user);
        }
    }
}