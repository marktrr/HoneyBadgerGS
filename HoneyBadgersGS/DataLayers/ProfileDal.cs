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

        public int Add(string profile)
        {
            _db.Profile.Add(profile);
            _db.SaveChangesAsync();
            return 1;
        }
        public int Update(string profile)
        {
            _db.Profile.Update(profile);
            _db.SaveChangesAsync();
            return 1;
        }
        public Profile GetData(string id)
        {
            Profile profile = _db.Profile.Find(id);
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