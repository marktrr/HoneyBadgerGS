using System.Collections.Generic;
using HoneyBadgers._0.DataLayers;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public class ProfileLogic : IProfileLogic
    {
        private readonly IProfileDal _profileDal;

        public ProfileLogic(IProfileDal profileDal)
        {
            _profileDal = profileDal;
        }


        public IEnumerable<Profile> GetAll()
        {
            return _profileDal.GetAll();
        }

        public int Add(Profile profile)
        {
            return _profileDal.Add(profile);
        }

        public int Update(Profile profile)
        {
            return _profileDal.Update(profile);
        }

        public Profile Details(int id)
        {
            return _profileDal.GetData(id);
        }
        public int Delete(int id)
        {
            return _profileDal.Delete(id);
        }
    }
}