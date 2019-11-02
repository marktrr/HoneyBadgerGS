using System.Collections.Generic;
using HoneyBadgers._0.Models;

namespace HoneyBadgers._0.BusinessLogic
{
    public interface IFriendListLogic
    {
        IEnumerable<FriendList> GetAll();
        int Add(FriendList friendList);
        int Update(FriendList friendList);
        FriendList Details(int id);
        int Delete(int id);
    }
}