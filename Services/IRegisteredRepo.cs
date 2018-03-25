using System;
using System.Collections.Generic;
using ServicePerks.Entities;

namespace ServicePerks.Services
{
    public interface IRegisteredRepo
    {
        void AddReg(Registered r);
        bool RegExists(string id);
        void DeleteReg(Registered r);
        Registered GetReg(string id);
        IEnumerable<Registered> GetAllReg();
        void UpdateUser(string id, Registered r);
        bool Save();
    }
}