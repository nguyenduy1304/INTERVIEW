namespace MSSQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("React")]
    public partial class React
    {
        [Key]
        [StringLength(50)]
        public string UniqueID { get; set; }

        [StringLength(50)]
        public string AccountID { get; set; }

        public int? ProductID { get; set; }

        public virtual Account Account { get; set; }

        public virtual Product Product { get; set; }
    }
}
