namespace VSS.DA.EF.VssDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InvoiceItem")]
    public partial class InvoiceItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long InvoiceItemId { get; set; }

        public long? InvoiceId { get; set; }

        public int? ItemId { get; set; }

        public int? PriceId { get; set; }

        public decimal? Qty { get; set; }

        [Column(TypeName = "money")]
        public decimal? Tax { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        public int? DoneBy { get; set; }

        public DateTime? DoneDate { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual Item Item { get; set; }
    }
}
