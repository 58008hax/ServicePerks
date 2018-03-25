using System;
using System.Collections.Generic;
using System.Linq;
using ServicePerks.Entities;

namespace ServicePerks.Services
{
    public class RegisteredRepo : IRegisteredRepo
    {
        private ServicePerksDBContext _context;

        public RegisteredRepo(ServicePerksDBContext context)
        {
            _context = context;
        }

        public void AddReg(Registered r)
        {
            _context.Registered.Add(r);
        }

        public bool RegExists(string id)
        {
            return _context.Registered.Any(x => x.Id == id);
        }

        public void DeleteReg(Registered r)
        {
            _context.Registered.Remove(r);
        }

        public Registered GetReg(string id)
        {
            return _context.Registered.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Registered> GetAllReg()
        {
            return _context.Registered.OrderBy(x => x.Id).ToList();
        }

        public void UpdateUser(string id, Registered r)
        {
            var currReg = _context.Registered.FirstOrDefault(x => x.Id == id);

            currReg.EventCode = r.EventCode;
            currReg.UserEmail = r.UserEmail;
            currReg.Attended = r.Attended;

            _context.Registered.Update(currReg);
            _context.SaveChanges();
        }
        
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}