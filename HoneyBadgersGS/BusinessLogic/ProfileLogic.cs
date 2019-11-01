using System;
using System.Collections.Generic;
using HoneyBadgers._0.DataLayers;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public class ProfileLogic : IProfileLogic
    {
        private IProfileDal _profileDal;

        public ProfileLogic(IProfileDal profileDal)
        {
            _profileDal = profileDal;
        }


        public IEnumerable<Profile> GetAll()
        {
            return _profileDal.GetAll();
        }

		public bool Add(string profile)
		{
			Guid _profId = new Guid();
			if (string.IsNullOrWhiteSpace(profile))
			{
				throw new ArgumentNullException("profile id is empty");
			}
			if (!Guid.TryParse(profile, out _profId))
			{
				throw new Exception("profile id is invalid");
			}
			//create a new profile obj and provide the updated values from the body being sent.
			Profile result = new Profile();
			result.ProfileId = _profId.ToString();

			return _profileDal.Add(result);
		}

		public int Update(Profile profile)
        {
            return _profileDal.Update(profile);
        }

        public Profile Details(string id)
        {
            return _profileDal.GetData(id);
        }
        public int Delete(string id)
        {
            return _profileDal.Delete(id);
        }
    }
}