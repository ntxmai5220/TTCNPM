namespace BKFoodCourt.DatabaseAccess.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public int ID { get; set; }

        [Required]
        [StringLength(325)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string PassWord { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int TypeAccount { get; set; }
    }
}
