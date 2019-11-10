using System.Collections.Generic;
using System.Linq;
using HoneyBadgers._0.Models;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers._0.DataLayers
{
    public class ProfileDal : IProfileDal
    {
        private HoneyBadgerDBContext _db;

        public ProfileDal(HoneyBadgerDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Profile> GetAll()
        {
            return _db.Profile.ToList();
        }
        public bool Add(Profile profile)
        {
            _db.Profile.Add(profile);
            _db.SaveChangesAsync();
            return true;
        }
        public bool Update(Profile profile)
        {
            _db.Profile.Update(profile);
            _db.SaveChangesAsync();
            return true;
        }
        public Profile GetData(string id)
        {
            Profile profile = _db.Profile.Find(id);

			//if the object is null, just return an empty object
			if(profile == null)
			{
				profile = new Profile();
			}
            return profile;
        }

        public int Delete(string id)
        {
            Profile profile = _db.Profile.Find(id);
            _db.Profile.Remove(profile);
            _db.SaveChangesAsync();
            return 1;
        }
    }
}