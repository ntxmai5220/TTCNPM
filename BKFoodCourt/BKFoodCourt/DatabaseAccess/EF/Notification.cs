namespace BKFoodCourt.DatabaseAccess.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notification")]
    public partial class Notification
    {
        public int ID { get; set; }

        public int? CustomerID { get; set; }

        public int? DonHangID { get; set; }

        [StringLength(1000)]
        public string Infomation { get; set; }

        public bool State { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Timer { get; set; }

        public virtual Account Account { get; set; }

        public virtual DonHang DonHang { get; set; }
    }
}
