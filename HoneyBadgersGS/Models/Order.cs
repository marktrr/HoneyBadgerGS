using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyBadgers._0.Models
{
    public partial class Order
    {
        public Order()
        {

        }

        public int orderID { get; set; }

        public string customerInfo { get; set; }

        public string itemInfo { get; set; }
    }
}
