using System;
using System.Collections.Generic;

namespace HoneyBadgers_3._0.Models
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int? GameId { get; set; }
        public int? Rating1 { get; set; }

        public virtual Game Game { get; set; }
    }
}
