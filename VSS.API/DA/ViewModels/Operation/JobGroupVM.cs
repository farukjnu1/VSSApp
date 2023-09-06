using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSS.API.DA.ViewModels.Common;

namespace VSS.API.DA.ViewModels.Operation
{
    public class JobGroupVM:Pager
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
    }
}