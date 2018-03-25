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
                                               Email="mattaquiles@gmail.com", 
                                               Password="123pass",
                                               FirstName="Matthew",
                                               LastName="Aquiles",
                                               Type=1,
                                               TotalPoints=55000,
                                               PointsAvailable=1200,
                                               Saved=55});
                _context.Users.Add(new Users { Id="user2", 
                                               Email="scottrussel@gmail.com", 
                                               Password="scottpass123",
                                               FirstName="Scott",
                                               LastName="Russel",
                                               Type=1,
                                               TotalPoints=40000,
                                               PointsAvailable=2500,
                                               Saved=45});
                _context.Users.Add(new Users { Id="user3", 
                                               Email="tfals1@gmail.com", 
                                               Password="falsnumba1",
                                               FirstName="Thomas",
                                               LastName="Falsone",
                                               Type=01,
                                               TotalPoints=5000,
                                               PointsAvailable=700,
                                               Saved=12});
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
        public IActionResult CreateUser([FromBody]Users user)
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