using System;
using System.Collections.Generic;

namespace HoneyBadgers_3._0.Models
{
    public partial class Profile
    {
        public Profile()
        {
            Account = new HashSet<Account>();
        }

        public int ProfileId { get; set; }
        public byte[] ProfileImage { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string UserAddress { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Promotion { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}
