﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VSS.API.DA.ViewModels.Common;

namespace VSS.API.DA.ViewModels.Stores
{
    public class StoreReqVM:Pager
    {
        public long Id { get; set; }

        public int? WhId { get; set; }

        public int? ItemId { get; set; }

        public int? SupplierId { get; set; }

        public int? Qty { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }
        public int? ReqStatus { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateBy { get; set; }
        public string ItemName { get; set; }
        public string SupplierName { get; set; }
        public string WHName { get; set; }
        public string ReqStatusName { get; set; }
        
    }
}