using System.Collections.Generic;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.DataLayers
{
    public interface IProfileDal
    {
        IEnumerable<Profile> GetAll();
        int Add(string profile);
        int Update(string profile);
        Profile GetData(string id);
        int Delete(string id);
    }
}