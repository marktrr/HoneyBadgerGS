using System.Collections.Generic;
using System.Linq;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.DataLayers
{
    public class FriendListDal : IFriendListDal
    {
        private HoneyBadgerDBContext _db;

        public FriendListDal(HoneyBadgerDBContext db)
        {
            _db = db;
        }

        public IEnumerable<FriendList> GetAll()
        {
            return _db.FriendList.ToList();
        }

        public int Add(FriendList friendList)
        {
            _db.FriendList.Add(friendList);
            _db.SaveChangesAsync();
            return 1;
        }

        public int Update(FriendList friendList)
        {
            _db.FriendList.Update(friendList);
            _db.SaveChangesAsync();
            return 1;
        }

        public FriendList GetData(int id)
        {
            FriendList friendList = _db.FriendList.Find(id);
            return friendList;
        }

        public int Delete(int id)
        {
            FriendList friendList = _db.FriendList.Find(id);
            _db.FriendList.Remove(friendList);
            _db.SaveChangesAsync();
            return 1;
        }
    }
}