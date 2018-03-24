using System;
using System.Collections.Generic;
using System.Linq;
using ServicePerks.Entities;

namespace ServicePerks.Entities
{
    public class DbInitializer
    {
        public static void Initialize(ServicePerksDBContext context)
        {
            context.Database.EnsureCreated();

            if(context.Users.Any())
            {
                //db has been seeded
            }
            else
            {
                var users = new Users[]
                {
                    //PUT DAT GOOD GOOD DATA HURRRR
                    new Users{}, //Matt
                    new Users{}, //Scott
                    new Users{}  //Tom
                };

                foreach (Users u in users)
                {
                    context.Users.Add(u);
                }
                context.SaveChanges();
            }

            if(context.Events.Any())
            {
                //db has been seeded
            }
            else
            {
                var events = new Events[]
                {
                    //PUT DAT GOOD GOOD DATA HURRRR
                    new Events{},
                    new Events{},
                    new Events{} 
                };

                foreach (Events e in events)
                {
                    context.Events.Add(e);
                }
                context.SaveChanges();
            }

            if(context.Vendors.Any())
            {
                //db has been seeded
            }
            else
            {
                var vendors = new Vendors[]
                {
                    //PUT DAT GOOD GOOD DATA HURRRR
                    new Vendors{},
                    new Vendors{},
                    new Vendors{}
                };

                foreach (Vendors v in vendors)
                {
                    context.Vendors.Add(v);
                }
                context.SaveChanges();
            }

            if(context.Registered.Any())
            {
                //db has been seeded
            }
            else
            {
                var reg = new Registered[]
                {
                    //PUT DAT GOOD GOOD DATA HURRRR
                    new Registered{},
                    new Registered{},
                    new Registered{}
                };

                foreach (Registered r in reg)
                {
                    context.Registered.Add(r);
                }
                context.SaveChanges();
            }
        }
    }
}