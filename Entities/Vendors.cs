using System;
using System.ComponentModel.DataAnnotations;

namespace ServicePerks.Entities
{
    public class Vendors
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Offer { get; set; }
        public string OfferCode { get; set; }
        public int RedeemPoints { get; set; }
        public DateTime Expiration { get; set; }
        public int Value { get; set; }
    }
}