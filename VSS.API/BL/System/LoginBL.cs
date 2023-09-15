using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            oUser = _vssDb.Users.Where(x => x.UserName == model.UserName && x.UserPass == model.UserPass).Select(y => new UserVM()
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
            var listUserRole = _vssDb.UserRoles.Where(x => x.UserId == oUser.UserID).ToList();
            //var listMenuPermission = new List<MenuPermission>();
            foreach (var oUserRole in listUserRole)
            {
                var listMP = _vssDb.MenuPermissions.Where(x => x.RoleId == oUserRole.RoleId).ToList();
                //listMenuPermission.AddRange(listMP);
            }
            //listMenuPermission.GroupBy(x => x.MenuId);
            var listMenu = _vssDb.Menus.ToList();
            var listMenuPermission = _vssDb.MenuPermissions.ToList();
            List<Menu> listM = new List<Menu>();
            foreach (var menu in listMenu)
            {
                //listMenuPermission.Where(x=>x.MenuId == menu.MenuId).GroupBy(y=>y.MenuId).Max(z=>z.Max(a=>a.))
            }
            return oUser;
        }
    }
}