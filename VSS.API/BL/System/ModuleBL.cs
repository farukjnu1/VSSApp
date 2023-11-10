﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.System;

namespace VSS.API.BL.System
{
    public class ModuleBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        public IEnumerable<ModuleVM> Get(string phone, int pageIndex, int pageSize)
        {
            int nRow = _vssDb.Modules.Count();
            var listModule = _vssDb.Modules
                .Select(x => new ModuleVM
                {
                    ModuleId = x.ModuleId,
                    ModuleName = x.ModuleName,
                    ModulePath = x.ModulePath,
                    Description = x.Description,

                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    RowCount = nRow
                })
                .OrderBy(s => s.ModuleId)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
            return listModule;
        }
    }
}