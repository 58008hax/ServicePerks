using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ServicePerks.Entities;

namespace ServicePerks.Controllers
{
    [Route("api/[controller]")]
    public class VendorsController : Controller
    {
        private readonly ServicePerksDBContext _context;

        public VendorsController(ServicePerksDBContext context)
        {
            _context = context;

            if(_context.Vendors.Count() == 0)
            {
                _context.Vendors.Add(new Vendors { Id="vendor1"});
                _context.SaveChanges();
            }
        }
        
        [HttpGet]
        public IActionResult GetVendors()
        {
            var v = _context.Vendors.OrderBy(x => x.Expiration);
            return new JsonResult(v);
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(string id)
        {
            var v = _context.Vendors.FirstOrDefault(x => x.Id == id);
            return new JsonResult(v);
        }

        [HttpPost]
        public IActionResult CreateEvent(Vendors v)
        {
            _context.Vendors.Add(v);
            _context.SaveChanges();
            return new JsonResult(v);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvent(string id, Vendors v)
        {
            var currVendor = _context.Vendors.FirstOrDefault(x => x.Id == id);

            currVendor.Name = v.Name;
            currVendor.Offer = v.Offer;
            currVendor.OfferCode = v.OfferCode;
            currVendor.RedeemPoints = v.RedeemPoints;
            currVendor.Expiration = v.Expiration;

            _context.Vendors.Update(currVendor);
            _context.SaveChanges();

            return new JsonResult(v);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(Vendors v)
        {
            _context.Vendors.Remove(v);
            return new JsonResult(v);
        }
    }
}