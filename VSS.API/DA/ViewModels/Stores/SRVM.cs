using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VSS.API.DA.ViewModels.Common;

namespace VSS.API.DA.ViewModels.Stores
{
    public class SRVM:Pager
    {
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