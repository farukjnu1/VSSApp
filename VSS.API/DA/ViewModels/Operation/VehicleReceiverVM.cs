﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VSS.API.DA.ViewModels.Common;

namespace VSS.API.DA.ViewModels.Operation
{
    public class WorkGroupVM:Pager
    {
        public int WgId { get; set; }
        [StringLength(50)]
        public string WgName { get; set; }
        public int? EmployeeId { get; set; }
        [StringLength(300)]
        public string FullName { get; set; }
        public bool IsSelect { get; set; } = false;
    }
}