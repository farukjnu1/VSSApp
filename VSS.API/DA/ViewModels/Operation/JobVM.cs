using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VSS.API.DA.ViewModels.Common;

namespace VSS.API.DA.ViewModels.Operation
{
    public class JobVM:Pager
    {
        public int JobId { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        public int? JobGroupId { get; set; }
        public string JobGroupName { get; set; }

        public int? A { get; set; }

        public int? B { get; set; }

        public int? C { get; set; }

        public int? DurationA { get; set; }

        public int? DurationB { get; set; }

        public int? DurationC { get; set; }
    }
}