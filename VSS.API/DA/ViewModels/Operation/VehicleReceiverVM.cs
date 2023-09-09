using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VSS.API.DA.ViewModels.Operation
{
    public class WorkGroupVM
    {
        [StringLength(50)]
        public string WgName { get; set; }
        public int? EmployeeId { get; set; }
        [StringLength(300)]
        public string FullName { get; set; }
        public bool IsSelect { get; set; } = false;
    }
}