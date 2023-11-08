using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VSS.API.DA.ViewModels.Common;

namespace VSS.API.DA.ViewModels.HR
{
    public class DesignationVM: Pager
    {
        public int DesignateId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Short { get; set; }
    }
}