using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VSS.API.DA.ViewModels.Common;

namespace VSS.API.DA.ViewModels.Stores
{
    public class BrandModelVM:Pager
    {
        public int Id { get; set; }

        public int? BrandId { get; set; }

        [StringLength(25)]
        public string ModelCode { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }
    }
}