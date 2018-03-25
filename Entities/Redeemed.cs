using System;
using System.ComponentModel.DataAnnotations;

namespace ServicePerks.Entities
{
    public class Redeemed
    {
        public string Id { get; set; }
        public string OfferCode { get; set; }
        public string UserEmail { get; set; }
        public bool Used { get; set; }
    }
}