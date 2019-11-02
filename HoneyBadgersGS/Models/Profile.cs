using System;
using System.Collections.Generic;

namespace HoneyBadgers._0.Models
{
    public partial class Profile
    {
        public Profile()
        {
            Account = new HashSet<Account>();
        }

        public string ProfileId { get; set; }
        public byte[] ProfileImage { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string UserAddress { get; set; }
        public DateTime Dob { get; set; }
        public bool? Promotion { get; set; }
        public string ActualName { get; set; }
        public string DisplayName { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}
