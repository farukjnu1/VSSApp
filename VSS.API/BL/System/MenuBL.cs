using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Common;
using VSS.API.DA.ViewModels.HR;
using VSS.API.DA.ViewModels.System;

namespace VSS.API.BL.System
{
    public class MenuBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        public IEnumerable<MenuVM> Get(string phone, int pageIndex, int pageSize)
        {
            int nRow = _vssDb.Menus.Count();
            var listMenu = _vssDb.Menus
                .Select(x => new MenuVM
                {
                    MenuId = x.MenuId,
                    MenuName = x.MenuName,
                    MenuPath = x.MenuPath,

                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    RowCount = nRow
                })
                .OrderBy(s => s.MenuId)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
            return listMenu;
        }
    }
}