using System.Collections.Generic;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public interface IProfileLogic
    {
        IEnumerable<Profile> GetAll();
        bool Add(Profile profile);
        bool Update(Profile profile);
        Profile Details(string id);
        int Delete(string id);
    }
}