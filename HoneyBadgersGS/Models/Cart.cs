using System;
using System.Collections.Generic;

namespace HoneyBadgers._0.Models
{
    public partial class Cart
    {
        public string? AccountId { get; set; }
        public int? GameId { get; set; }
        public double? SubTotal { get; set; }
        public double? TaxRate { get; set; }
        public double? FinalPrice { get; set; }
        public int CartId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Game Game { get; set; }
    }
}
