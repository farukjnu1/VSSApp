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
    public class SRBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        List<StoreReq> listEngineSize = null;

        public IEnumerable<SRVM> Get(int pageIndex = 0, int pageSize = 10)
        {
            int nRow = _vssDb.Items.Count();
            var listSR = (from sr in _vssDb.StoreReqs
                          join i in _vssDb.Items on sr.ItemId equals i.Id
                          join w in _vssDb.Warehouses on sr.WhId equals w.Id
                          join s in _vssDb.BusinessPartners on sr.SupplierId equals s.BpId
                          select new SRVM
                          {
                              Id = sr.Id,
                              ItemId = sr.ItemId,
                              ItemName = i.ItemName,
                              //PurPrice = sr.PurPrice,
                              Qty = sr.Qty,
                              Remark = sr.Remark,
                              //SalePrice = sr.SalePrice,
                              SupplierId = sr.SupplierId,
                              SupplierName = s.Name,
                              WhId = sr.WhId,
                              WHName = w.Name,
                              PageIndex = pageIndex,
                              PageSize = pageSize,
                              RowCount = nRow
                          })
                .OrderByDescending(x => x.Id)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
            return listSR;
        }

        public bool Add(StoreReq model)
        {
            try
            {
                model.Id = GetNewId();
                model.CreateDate = DateTime.Now;
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
                var oSR = _vssDb.StoreReqs
                 .Where(x => x.Id == model.Id).FirstOrDefault();
                if (oSR != null)
                {
                    oSR.WhId = model.WhId;
                    oSR.ItemId = model.ItemId;
                    oSR.SupplierId = model.SupplierId;
                    //oSR.PurPrice = model.PurPrice;
                    //oSR.SalePrice = model.SalePrice;
                    oSR.Remark = model.Remark;
                    oSR.UpdateBy = model.CreateBy;
                    oSR.UpdateDate = DateTime.Now;
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