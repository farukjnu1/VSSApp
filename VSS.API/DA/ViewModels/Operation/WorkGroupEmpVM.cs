using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VSS.API.DA.ViewModels.Common;

namespace VSS.API.DA.ViewModels.Operation
{
    public class WorkGroupEmpVM:Pager
    {
        public int Id { get; set; }

        public int? WgId { get; set; }

        [StringLength(50)]
        public string WgName { get; set; }

        public int? EmpId { get; set; }
        public string FirstName { get; set; }

        [StringLength(150)]
        public string MiddleName { get; set; }

        [StringLength(150)]
        public string LastName { get; set; }
    }
}