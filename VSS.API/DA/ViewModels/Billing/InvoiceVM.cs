﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VSS.API.DA.ViewModels.Billing
{
    public class InvoiceVM
    {
        public long Id { get; set; }

        public int? ClientId { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateBy { get; set; }

        public bool? IsPaid { get; set; }

        public long? JcId { get; set; }

        public decimal? GrandTotal { get; set; }

        public int? InvoiceStatus { get; set; }
        public List<InvoiceItemVM> InvoiceItems { get; set; } = new List<InvoiceItemVM>();
        public string JcNo { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string ClientEmail { get; set; }
        public string ClientAddress { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonNo { get; set; }
        public string Description { get; set; }
    }

    public class InvoiceItemVM
    {
        public long Id { get; set; }

        public long? InvoiceId { get; set; }

        public int? ItemId { get; set; }

        public int? ItemType { get; set; }

        public decimal? Qty { get; set; }

        public decimal? UnitPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? Tax { get; set; }

        public int? DoneBy { get; set; }

        public DateTime? DoneDate { get; set; }

        public decimal? TotalPrice { get; set; }

        public decimal? Discount { get; set; }

        public decimal? DiscountAmount { get; set; }

        public decimal? TpAfterDiscount { get; set; }

        public decimal? Vat { get; set; }

        public decimal? TotalVat { get; set; }

        public decimal? TotalAmount { get; set; }
    }
}