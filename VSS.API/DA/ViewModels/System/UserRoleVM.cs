using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSS.API.DA.EF.VssDb;

namespace VSS.API.DA.ViewModels.System
{
    public class UserRoleVM
    {
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public int? UserId { get; set; }
        public bool IsSelect { get; set; } = false;
    }
}