using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServicePerks.Entities;

namespace ServicePerks.Controllers
{
    [Route("api/[controller]")]
    public class RedeemedController : Controller
    {
        private readonly ServicePerksDBContext _context;

        public RedeemedController(ServicePerksDBContext context)
        {
            _context = context;

            if(_context.Redeemed.Count() == 0)
            {
                _context.Redeemed.Add(new Redeemed { Id="red1",
                                                     OfferCode="vendor1",
                                                     UserEmail="mattaquiles@gmail.com",
                                                     Used=false});
                _context.Redeemed.Add(new Redeemed { Id="red2",
                                                     OfferCode="vendor2",
                                                     UserEmail="mattaquiles@gmail.com",
                                                     Used=false});
                _context.Redeemed.Add(new Redeemed { Id="red3",
                                                     OfferCode="vendor3",
                                                     UserEmail="mattaquiles@gmail.com",
                                                     Used=false});
                _context.SaveChanges();
            }
        }
        
        [HttpGet]
        public IActionResult GetRedeemed()
        {
            var r = _context.Redeemed.OrderBy(x => x.Id);
            return new JsonResult(r);
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(string id)
        {
            var r = _context.Redeemed.FirstOrDefault(x => x.Id == id);
            return new JsonResult(r);
        }

        [HttpPost]
        public IActionResult CreateEvent(Redeemed r)
        {
            _context.Redeemed.Add(r);
            _context.SaveChanges();
            return new JsonResult(r);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvent(string id, Redeemed r)
        {
            var currReg = _context.Redeemed.FirstOrDefault(x => x.Id == id);

            currReg.OfferCode = r.OfferCode;
            currReg.UserEmail = r.UserEmail;
            currReg.Used = r.Used;

            _context.Redeemed.Update(currReg);
            _context.SaveChanges();

            return new JsonResult(r);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(Redeemed r)
        {
            _context.Redeemed.Remove(r);
            return new JsonResult(r);
        }
    }
}