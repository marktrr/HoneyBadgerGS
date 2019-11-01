using System.Collections.Generic;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public interface IProfileLogic
    {
        IEnumerable<Profile> GetAll();
        int Add(string profile);
        int Update(string profile);
        Profile Details(string id);
        int Delete(string id);
    }
}