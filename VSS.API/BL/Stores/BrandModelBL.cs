using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Stores;

namespace VSS.API.BL.Stores
{
    public class BrandModelBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        public IEnumerable<BrandModelVM> Get(string phone, int pageIndex, int pageSize)
        {
            int nRow = _vssDb.BrandModels.Count();
            var listBrandModel = _vssDb.BrandModels
                .Select(x => new BrandModelVM
                {
                    Id = x.Id,
                    BrandId = x.BrandId,
                    ModelCode = x.ModelCode,
                    Remarks = x.Remarks,

                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    RowCount = nRow
                })
                .OrderBy(s => s.Id)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
            return listBrandModel;
        }

        public bool Add(BrandModel model)
        {
            try
            {
                model.Id = GetNewId();
                model.BrandId = model.BrandId;
                model.ModelCode = model.ModelCode;
                model.Remarks = model.Remarks;
                _vssDb.BrandModels.Add(model);
                _vssDb.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(BrandModel model)
        {
            try
            {
                var oBM = _vssDb.BrandModels
                 .Where(x => x.Id == model.Id)
                 .FirstOrDefault();
                if (oBM != null)
                {
                    oBM.Id = model.Id;
                    oBM.BrandId = model.BrandId;
                    oBM.ModelCode = model.ModelCode;
                    oBM.Remarks = model.Remarks;
                    _vssDb.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool Remove(int id)
        {
            try
            {
                var selectedBrandModel = _vssDb.BrandModels
                 .Where(x => x.Id == id)
                 .FirstOrDefault();
                if (selectedBrandModel != null)
                {
                    _vssDb.BrandModels.Remove(selectedBrandModel);
                    _vssDb.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        private int GetNewId()
        {
            try
            {
                var Id = Convert.ToInt32(_vssDb.BrandModels.Max(x => x.Id)) + 1;
                return Id;
            }
            catch
            {
                return 0;
            }
        }
    }
}