using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneyBadgers._0.Models
{
    public partial class Review
    {
		[Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ReviewId { get; set; }
        public string AccountId { get; set; }
        public int? GameId { get; set; }
        public string ReviewInfo { get; set; }
        public int? RatingValue { get; set; }

        public virtual Game Game { get; set; }
    }
}
