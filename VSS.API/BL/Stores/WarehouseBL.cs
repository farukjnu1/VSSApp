using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Stores;

namespace VSS.API.BL.Stores
{
    public class WarehouseBL
    {
        ModelVssDb _vssDb = new ModelVssDb();

        public IEnumerable<WarehouseVM> GetWarehouse()
        {
            var listWarehouse = _vssDb.Warehouses
                .Select(x => new WarehouseVM
                {
                    Id = x.Id,
                    Name = x.Name
                }).OrderBy(s => s.Name).ToList();
            return listWarehouse;
        }
    }
}