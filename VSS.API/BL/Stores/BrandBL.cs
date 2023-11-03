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
        ModelVssDb _vssDb = null;
        public IEnumerable<BrandVM> GetBrand()
        {
            _vssDb = new ModelVssDb();
            var listBrand = _vssDb.Brands
                .Select(x => new BrandVM
                {
                    Id = x.Id,
                    Name = x.Name
                }).OrderBy(s=>s.Name).ToList();
            return listBrand;
        }
        public IEnumerable<ItemCategoryVM> GetItemCategory()
        {
            _vssDb = new ModelVssDb();
            var listItemCategory = _vssDb.ItemCategories
                .Select(x => new ItemCategoryVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code
                }).OrderBy(s => s.Name).ToList();
            return listItemCategory;
        }
    }
}