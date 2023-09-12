using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;
using VSS.API.DA.ViewModels.Stores;

namespace VSS.API.BL.Stores
{
    public class SRBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        List<StoreReq> listEngineSize = null;

        public IEnumerable<StoreReq> Get()
        {
            return listEngineSize = _vssDb.StoreReqs.ToList();
        }

        public bool Add(StoreReq model)
        {
            try
            {
                model.Id = GetNewId();
                _vssDb.StoreReqs.Add(model);
                _vssDb.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(StoreReq model)
        {
            try
            {
                var selectedItem = _vssDb.StoreReqs
                 .Where(x => x.Id == model.Id).FirstOrDefault();
                if (selectedItem != null)
                {
                    selectedItem.WhId = model.WhId;
                    selectedItem.ItemId = model.ItemId;
                    selectedItem.SupplierId = model.SupplierId;
                    selectedItem.PurPrice = model.PurPrice;
                    selectedItem.SalePrice = model.SalePrice;
                    selectedItem.Remark = model.Remark;
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
                var selectedId = _vssDb.StoreReqs
                 .Where(x => x.Id == id)
                 .FirstOrDefault();
                if (selectedId != null)
                {
                    _vssDb.StoreReqs.Remove(selectedId);
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
                var Id = Convert.ToInt32(_vssDb.StoreReqs.Max(x => x.Id)) + 1;
                return Id;
            }
            catch
            {
                return 0;
            }
        }
    }
}