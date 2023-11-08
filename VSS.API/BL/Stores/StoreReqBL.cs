using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using VSS.API.DA.ADO;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.Utilities;
using VSS.API.DA.ViewModels.Operation;
using VSS.API.DA.ViewModels.Stores;
using VSS.DA.ADO;
using VSS.DA.ViewModels.Operation;

namespace VSS.API.BL.Stores
{
    public class StoreReqBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        List<StoreReq> listEngineSize = null;
        private IGenericFactory<StoreReqVM> Generic_StoreReq = null;

        public List<StoreReqVM> Get(int reqStatus, int pageIndex = 0, int pageSize = 10)
        {
            string vssDb = ConfigurationManager.ConnectionStrings["VssDb"].ConnectionString;
            Generic_StoreReq = new GenericFactory<StoreReqVM>();
            return Generic_StoreReq.ExecuteCommandList(CommandType.StoredProcedure, StoredProcedure.sp_GetStoreReq, new Hashtable() { { "PageIndex", pageIndex }, { "PageSize", pageSize }, { "ReqStatus", reqStatus } }, vssDb);
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
                var oStoreReq = _vssDb.StoreReqs
                 .Where(x => x.Id == model.Id).FirstOrDefault();
                if (oStoreReq != null)
                {
                    if (oStoreReq.ReqStatus == (int)BLStatus.ReqStatus.Initial)
                    {
                        oStoreReq.WhId = model.WhId;
                        oStoreReq.ItemId = model.ItemId;
                        oStoreReq.SupplierId = model.SupplierId;
                        oStoreReq.Remark = model.Remark;
                        oStoreReq.Qty = model.Qty;
                        oStoreReq.ReqStatus = model.ReqStatus;
                        oStoreReq.UpdateBy = model.CreateBy;
                        oStoreReq.UpdateDate = DateTime.Now;
                        _vssDb.SaveChanges();
                        return true;
                    }
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
                var oStoreReq = _vssDb.StoreReqs
                 .Where(x => x.Id == id)
                 .FirstOrDefault();
                if (oStoreReq != null)
                {
                    if (oStoreReq.ReqStatus == (int)BLStatus.ReqStatus.Initial)
                    {
                        _vssDb.StoreReqs.Remove(oStoreReq);
                        _vssDb.SaveChanges();
                        return true;
                    }
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