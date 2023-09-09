using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;
using VSS.API.DA.ViewModels.Stores;

namespace VSS.API.BL.Stores
{
    public class BrandBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        public IEnumerable<BrandVM> GetBrand()
        {
            var listBrand = _vssDb.Brands
                .Select(x => new BrandVM
                {
                    Id = x.Id,
                    Name = x.Name
                }).OrderBy(s=>s.Name).ToList();
            return listBrand;
        }
    }
}