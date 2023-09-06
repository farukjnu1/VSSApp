using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VSS.API.DA.ViewModels.Common
{
    public class Pager
    {
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public int PageCount { get; set; } = 0;
    }
}