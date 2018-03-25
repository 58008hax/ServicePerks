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
                _context.Vendors.Add(new Vendors { Id="vendor1",
                                                   Name="Benny Tudino's",
                                                   Offer="Free Slice of Pizza",
                                                   OfferCode="free123",
                                                   RedeemPoints=500 ,
                                                   Expiration= new DateTime(2018, 4, 15),
                                                   Value=4});
                _context.Vendors.Add(new Vendors { Id="vendor2",
                                                   Name="Tally-Ho",
                                                   Offer="2 Hour Happy Hour",
                                                   OfferCode="happy2hour",
                                                   RedeemPoints=3000 ,
                                                   Expiration= new DateTime(2018, 5, 1),
                                                   Value=30});
                _context.Vendors.Add(new Vendors { Id="vendor3",
                                                   Name="Pokebowl",
                                                   Offer="20% off order of $10 or more",
                                                   OfferCode="20perc10",
                                                   RedeemPoints=500 ,
                                                   Expiration= new DateTime(2018, 4, 1),
                                                   Value=5});
                _context.Vendors.Add(new Vendors { Id="vendor4",
                                                   Name="Pierce Dining Hall",
                                                   Offer="One Free Meal Swipe",
                                                   OfferCode="freeswipe1",
                                                   RedeemPoints=1000 ,
                                                   Expiration= new DateTime(2018, 4, 30),
                                                   Value=10});
                _context.Vendors.Add(new Vendors { Id="vendor5",
                                                   Name="Q'Doba",
                                                   Offer="Free side with meal purchase",
                                                   OfferCode="freeside1",
                                                   RedeemPoints=400 ,
                                                   Expiration= new DateTime(2018, 4, 20),
                                                   Value=4});
                _context.Vendors.Add(new Vendors { Id="vendor6",
                                                   Name="Stevens School Store",
                                                   Offer="20% off purchase",
                                                   OfferCode="20percbooks",
                                                   RedeemPoints=500 ,
                                                   Expiration= new DateTime(2018, 6, 1),
                                                   Value=5});
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
            currVendor.Value = v.Value;

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