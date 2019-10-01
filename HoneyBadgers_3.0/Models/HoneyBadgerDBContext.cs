using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HoneyBadgers_3._0.Models
{
    public partial class HoneyBadgerDBContext : DbContext
    {
        public HoneyBadgerDBContext()
        {
        }

        public HoneyBadgerDBContext(DbContextOptions<HoneyBadgerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<FriendList> FriendList { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId)
                    .HasColumnName("accountID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LibraryId).HasColumnName("libraryID");

                entity.Property(e => e.ProfileId).HasColumnName("profileID");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasColumnName("userPassword")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK_Account_profileID");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId)
                    .HasColumnName("cartID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountId).HasColumnName("accountID");

                entity.Property(e => e.FinalPrice).HasColumnName("finalPrice");

                entity.Property(e => e.GameId).HasColumnName("gameID");

                entity.Property(e => e.SubTotal).HasColumnName("subTotal");

                entity.Property(e => e.TaxRate).HasColumnName("taxRate");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Cart_AccountID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_Cart_gameID");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventId)
                    .HasColumnName("eventID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountId).HasColumnName("accountID");

                entity.Property(e => e.DateOfEvent)
                    .HasColumnName("dateOfEvent")
                    .HasColumnType("datetime");

                entity.Property(e => e.EventDescription)
                    .HasColumnName("eventDescription")
                    .HasColumnType("text");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("text");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Event_accountID");
            });

            modelBuilder.Entity<FriendList>(entity =>
            {
                entity.Property(e => e.FriendListId)
                    .HasColumnName("friendListID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountId).HasColumnName("accountID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.FriendList)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_FriendList_accountID");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameId)
                    .HasColumnName("gameID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Developer)
                    .HasColumnName("developer")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Flatform)
                    .HasColumnName("flatform")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GameDescription)
                    .HasColumnName("gameDescription")
                    .HasColumnType("text");

                entity.Property(e => e.GameName)
                    .HasColumnName("gameName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Publisher)
                    .HasColumnName("publisher")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("releaseDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SystemReq)
                    .HasColumnName("systemReq")
                    .HasColumnType("text");

                entity.Property(e => e.WishlistId).HasColumnName("wishlistID");

                entity.HasOne(d => d.Wishlist)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.WishlistId)
                    .HasConstraintName("game_FK_wishlistID");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.Property(e => e.ProfileId)
                    .HasColumnName("profileID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImage)
                    .HasColumnName("profileImage")
                    .HasColumnType("image");

                entity.Property(e => e.Promotion).HasColumnName("promotion");

                entity.Property(e => e.UserAddress)
                    .HasColumnName("userAddress")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.RatingId)
                    .HasColumnName("ratingID")
                    .ValueGeneratedNever();

                entity.Property(e => e.GameId).HasColumnName("gameID");

                entity.Property(e => e.Rating1).HasColumnName("rating");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_Rating_accountID");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId)
                    .HasColumnName("reviewID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountId).HasColumnName("accountID");

                entity.Property(e => e.GameId).HasColumnName("gameID");

                entity.Property(e => e.ReviewInfo)
                    .HasColumnName("reviewInfo")
                    .HasColumnType("text");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("PK_Review_accountID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("PK_Review_gameID");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.Property(e => e.SalesId)
                    .HasColumnName("salesID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountId).HasColumnName("accountID");

                entity.Property(e => e.GameId).HasColumnName("gameID");

                entity.Property(e => e.TimeOfSales)
                    .HasColumnName("timeOfSales")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Sales_accountID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_Sales_gameID");
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.Property(e => e.WishlistId)
                    .HasColumnName("wishlistID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountId).HasColumnName("accountID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Wishlist)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_wishlist_accountID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
