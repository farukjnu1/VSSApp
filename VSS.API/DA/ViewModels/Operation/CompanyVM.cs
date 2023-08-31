using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VSS.API.DA.ViewModels.Operation
{
    public class CompanyVM
    {
        public int CompanyId { get; set; }

        [StringLength(10)]
        public string CompanyCode { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        [StringLength(25)]
        public string DateFormat { get; set; }

        public int? DecimalPlace { get; set; }

        public int? Bay { get; set; }

        public decimal? Vat { get; set; }

        public bool? IsActive { get; set; }
    }
}