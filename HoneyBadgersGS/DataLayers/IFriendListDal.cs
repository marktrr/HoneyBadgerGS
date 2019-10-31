using System.Collections.Generic;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.DataLayers
{
    public interface IFriendListDal
    {
        IEnumerable<FriendList> GetAll();
        int Add(FriendList friend);
        int Update(FriendList friend);
        FriendList GetData(int id);
        int Delete(int id);
    }
}
