namespace VSS.API.DA.EF.VssDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StoreRec")]
    public partial class StoreRec
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public int? WhId { get; set; }

        public decimal? PurchasePrice { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BusinessPartnerId { get; set; }

        public int? ItemId { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        public int? StoreRecTypeId { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? UpdateBy { get; set; }
    }
}
