using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.System;

namespace VSS.API.BL.System
{
    public class RoleBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        internal IEnumerable<RoleVM> get()
        {
            var listRole = _vssDb.Roles
                .Select(x => new RoleVM
                {
                    RoleId = x.RoleId,
                    RoleName = x.RoleName,
                }).OrderBy(s => s.RoleId).ToList();
            return listRole;
        }
    }
}