using System;
using System.Collections.Generic;
using System.Linq;
using ServicePerks.Entities;

namespace ServicePerks.Services
{
    public class UsersRepo : IUsersRepo
    {
        private ServicePerksDBContext _context;

        public UsersRepo(ServicePerksDBContext context)
        {
            _context = context;

            if(_context.Users.Count() == 0)
            {
                _context.Users.Add(new Users { Id="1a", Email="test@email.com", Password="123pass"});
                _context.SaveChanges();
            }
        }

        public void AddUser(Users user)
        {
            _context.Users.Add(user);
        }

        public bool UserExists(string email)
        {
            return _context.Users.Any(x => x.Email == email);
        }

        public void DeleteUser(Users user)
        {
            _context.Users.Remove(user);
        }

        public Users GetUser(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _context.Users.OrderBy(x => x.Email).ToList();
        }
        
        public void UpdateUser(string email, Users user)
        {
            var currUser = _context.Users.FirstOrDefault(x => x.Email == email);

            currUser.Email = user.Email;
            currUser.Password = user.Password;
            currUser.FirstName = user.FirstName;
            currUser.LastName = user.LastName;
            currUser.Type = user.Type;
            currUser.points = user.points;

            _context.Users.Update(currUser);
            _context.SaveChanges();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}