using System;

namespace HoneyBadgers._0.Models
{
    public partial class Sales
    {
        public int SalesId { get; set; }
        public int? GameId { get; set; }
        public int? AccountId { get; set; }
        public DateTime? TimeOfSales { get; set; }

        public virtual Account Account { get; set; }
        public virtual Game Game { get; set; }
    }
}
