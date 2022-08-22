namespace MSSQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Reacts = new HashSet<React>();
        }

        [Key]
        public int UniqueID { get; set; }

        public string Title { get; set; }

        [StringLength(255)]
        public string PICTURE { get; set; }

        public DateTime? CreateDateTime { get; set; }

        [StringLength(50)]
        public string React { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<React> Reacts { get; set; }
    }
}
