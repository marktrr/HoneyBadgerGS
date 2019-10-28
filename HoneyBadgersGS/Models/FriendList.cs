using System;
using System.Collections.Generic;

namespace HoneyBadgers._0.Models
{
    public partial class FriendList
    {
        public string FriendListId { get; set; }
        public string ? AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
