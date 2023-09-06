namespace VSS.API.DA.EF.VssDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StoreReq")]
    public partial class StoreReq
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public int? WhId { get; set; }

        public int? ItemId { get; set; }

        public int? SupplierId { get; set; }

        public int? Qty { get; set; }

        public decimal? PurPrice { get; set; }

        public decimal? SalePrice { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }
    }
}
