namespace BKFoodCourt.DatabaseAccess.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        public int ID { get; set; }

        public int FoodID { get; set; }

        public int Quantily { get; set; }

        public int OrderID { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual Food Food { get; set; }
    }
}
