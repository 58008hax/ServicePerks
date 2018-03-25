using System;
using System.Collections.Generic;
using System.Linq;
using ServicePerks.Entities;

namespace ServicePerks.Services
{
    public class VendorsRepo : IVendorsRepo
    {
        private ServicePerksDBContext _context;

        public VendorsRepo(ServicePerksDBContext context)
        {
            _context = context;
        }

        public void AddVendor(Vendors vendor)
        {
            _context.Vendors.Add(vendor);
        }

        public bool VendorExists(string id)
        {
            return _context.Vendors.Any(x => x.Id == id);
        }

        public void DeleteVendor(Vendors vendor)
        {
            _context.Vendors.Remove(vendor);
        }

        public Vendors GetVendor(string id)
        {
            return _context.Vendors.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Vendors> GetAllVendors()
        {
            return _context.Vendors.OrderBy(x => x.Expiration).ToList();
        }

        public void UpdateVendor(string id, Vendors vendor)
        {
            var currVendor = _context.Vendors.FirstOrDefault(x => x.Id == id);

            currVendor.Name = vendor.Name;
            currVendor.Offer = vendor.Offer;
            currVendor.OfferCode = vendor.OfferCode;
            currVendor.RedeemPoints = vendor.RedeemPoints;
            currVendor.Expiration = vendor.Expiration;

            _context.Vendors.Update(currVendor);
            _context.SaveChanges();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}