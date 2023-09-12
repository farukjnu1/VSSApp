using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.System;

namespace VSS.API.BL.System
{
    public class UserBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        public IEnumerable<UserVM> Get()
        {
            var listUser = _vssDb.Users
                .Select(x => new UserVM
                {
                    UserID = x.UserID,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    Email = x.Email,
                    MobileNo = x.MobileNo,
                }).OrderBy(s => s.FirstName).ToList();
            return listUser;
        }
    }
}