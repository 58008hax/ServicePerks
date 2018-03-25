using System;
using System.Collections.Generic;
using ServicePerks.Entities;

namespace ServicePerks.Services
{
    public interface IVendorsRepo
    {
        void AddVendor(Vendors vendor);
        bool VendorExists(string id);
        void DeleteVendor(Vendors vendor);
        Vendors GetVendor(string id);
        IEnumerable<Vendors> GetAllVendors();
        void UpdateVendor(string id, Vendors vendor);
        bool Save();
    }
}