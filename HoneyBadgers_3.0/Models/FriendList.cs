using System;
using System.Collections.Generic;

namespace HoneyBadgers_3._0.Models
{
    public partial class FriendList
    {
        public int FriendListId { get; set; }
        public int? AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
