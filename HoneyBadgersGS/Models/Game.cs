using System;
using System.Collections.Generic;

namespace HoneyBadgers._0.Models
{
    public partial class Game
    {
        public Game()
        {
            Cart = new HashSet<Cart>();
            Rating = new HashSet<Rating>();
            Review = new HashSet<Review>();
            Sales = new HashSet<Sales>();
        }

        public int GameId { get; set; }
        public int? WishlistId { get; set; }
        public string GameName { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string GameDescription { get; set; }
        public string SystemReq { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string GameArtUrl { get; set; }
        public double price { get; set; }
        public virtual Wishlist Wishlist { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
