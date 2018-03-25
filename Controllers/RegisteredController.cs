using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServicePerks.Entities;

namespace ServicePerks.Controllers
{
    [Route("api/[controller]")]
    public class RegisteredController : Controller
    {
        private readonly ServicePerksDBContext _context;

        public RegisteredController(ServicePerksDBContext context)
        {
            _context = context;

            if(_context.Registered.Count() == 0)
            {
                _context.Registered.Add(new Registered { Id="reg1",
                                                         EventCode="event1",
                                                         UserEmail="mattaquiles@gmail.com",
                                                         Attended=false});
                _context.Registered.Add(new Registered { Id="reg1",
                                                         EventCode="event2",
                                                         UserEmail="mattaquiles@gmail.com",
                                                         Attended=false});
                _context.Registered.Add(new Registered { Id="reg1",
                                                         EventCode="event3",
                                                         UserEmail="mattaquiles@gmail.com",
                                                         Attended=false});
                _context.SaveChanges();
            }
        }
        
        [HttpGet]
        public IActionResult GetRegistered()
        {
            var r = _context.Registered.OrderBy(x => x.Id);
            return new JsonResult(r);
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(string id)
        {
            var r = _context.Registered.FirstOrDefault(x => x.Id == id);
            return new JsonResult(r);
        }

        [HttpPost]
        public IActionResult CreateEvent(Registered r)
        {
            _context.Registered.Add(r);
            _context.SaveChanges();
            return new JsonResult(r);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvent(string id, Registered r)
        {
            var currReg = _context.Registered.FirstOrDefault(x => x.Id == id);

            currReg.EventCode = r.EventCode;
            currReg.UserEmail = r.UserEmail;
            currReg.Attended = r.Attended;

            _context.Registered.Update(currReg);
            _context.SaveChanges();

            return new JsonResult(r);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(Registered r)
        {
            _context.Registered.Remove(r);
            return new JsonResult(r);
        }
    }
}