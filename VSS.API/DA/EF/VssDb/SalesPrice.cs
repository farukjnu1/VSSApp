namespace VSS.API.DA.EF.VssDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SalesPrice")]
    public partial class SalesPrice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public decimal? SalePrice { get; set; }

        public int? ItemId { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateBy { get; set; }
    }
}
