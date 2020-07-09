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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            DonHangs = new HashSet<DonHang>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
