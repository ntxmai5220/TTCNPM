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
        public virtual DbSet<Food> Foods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.PassWord)
                .IsFixedLength();
        }
    }
}
