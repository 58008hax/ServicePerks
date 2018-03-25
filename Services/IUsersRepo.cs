using System;
using System.Collections.Generic;
using ServicePerks.Entities;

namespace ServicePerks.Services
{
    public interface IUsersRepo
    {
        void AddUser(Users user);
        bool UserExists(string email);
        void DeleteUser(Users user);
        Users GetUser(string email);
        IEnumerable<Users> GetAllUsers();
        void UpdateUser(string id, Users user);
        bool Save();
    }
}