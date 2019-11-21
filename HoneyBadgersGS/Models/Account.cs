using System;
using System.Collections.Generic;

namespace HoneyBadgers._0.Models
{
    public partial class Account
    {
        public string AccountId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string ProfileId { get; set; }
        public int? LibraryId { get; set; }

        public virtual AspNetUsers AccountNavigation { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
