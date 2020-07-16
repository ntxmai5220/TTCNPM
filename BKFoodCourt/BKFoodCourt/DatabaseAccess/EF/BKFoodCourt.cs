namespace BKFoodCourt.DatabaseAccess.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BKFoodCourt : DbContext
    {
        public BKFoodCourt()
            : base("name=BKFoodCourt")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.PassWord)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.CustomerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Notifications)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.CustomerID);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.OrderCode)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.DonHang)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Food>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Food)
                .WillCascadeOnDelete(false);
        }
    }
}
