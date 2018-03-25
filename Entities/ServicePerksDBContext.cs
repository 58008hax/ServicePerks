using System;
using Microsoft.EntityFrameworkCore;

namespace ServicePerks.Entities
{
    public class ServicePerksDBContext : DbContext
    {
        public ServicePerksDBContext(DbContextOptions<ServicePerksDBContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Vendors> Vendors { get; set; }
        public DbSet<Registered> Registered { get; set; }
        public DbSet<Redeemed> Redeemed { get; set; }
        
    }
}