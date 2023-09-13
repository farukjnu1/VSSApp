using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VSS.API.DA.ViewModels.System
{
    public class RoleVM
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public bool? IsActive { get; set; }
    }
}