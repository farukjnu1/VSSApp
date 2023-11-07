namespace VSS.API.DA.EF.VssDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        public int Id { get; set; }

        public int? WhId { get; set; }

        public int? ItemId { get; set; }

        public decimal? Qty { get; set; }
    }
}
