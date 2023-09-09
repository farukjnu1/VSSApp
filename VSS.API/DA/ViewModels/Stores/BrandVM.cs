using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VSS.API.DA.ViewModels.Stores
{
    public class BrandVM
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(250)]
        public string Remarks { get; set; }

        public bool? IsActive { get; set; }
    }
}