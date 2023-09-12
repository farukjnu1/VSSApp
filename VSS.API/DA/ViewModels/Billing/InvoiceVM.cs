using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VSS.API.DA.ViewModels.Billing
{
    public class InvoiceVM
    {
        public long InvoiceId { get; set; }

        public int? ClientId { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateBy { get; set; }

        public bool? IsPaid { get; set; }

        public long? JcId { get; set; }
        public List<InvoiceItemVM> listInvoiceItem { get; set; }
    }

    public class InvoiceItemVM
    {
        public long Id { get; set; }

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
    }
}