using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using VSS.API.Attributes;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.System;

namespace VSS.API.BL.System
{
    public class LoginBL
    {
        ModelVssDb _vssDb = null;
        public UserVM Login(UserVM model)
        {
            UserVM oUser = null;
            _vssDb = new ModelVssDb();
            oUser = _vssDb.Users.Where(x => x.UserName == model.UserName && x.UserPass == model.UserPass && x.IsActive == true).Select(y => new UserVM()
            {
                UserName = y.UserName,
                UserPass = y.UserPass,
                FirstName = y.FirstName,
                MiddleName = y.MiddleName,
                LastName = y.LastName,
                UserID = y.UserID,
                UserCode = y.UserCode,
                Email = y.Email,
                MobileNo = y.MobileNo
            }).FirstOrDefault();
            if (oUser != null) 
            {
                NameValueCollection myKeys = ConfigurationManager.AppSettings;
                int tokenExpire = Convert.ToInt32(myKeys["TokenExpire"]);
                string VSS = myKeys["VSS"];
                oUser.Permissions = new MenuPermissionBL().GetMenuByUser(oUser.UserID);
                oUser.Token = JsonWebToken.Encode(new UserPayload() { CreateDate = DateTime.Now, UserId = oUser.UserID, TokenExpire = tokenExpire, UserName = oUser.UserName }, VSS, JwtHashAlgorithm.HS512);
            }          
            return oUser;
        }
    }
}