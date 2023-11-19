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
    public class JcReqBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        private IGenericFactory<JcReqVM> Generic_JcReq = null;

        public List<JcReqVM> Get(int reqStatus, int storeTranTypeId, int pageIndex = 0, int pageSize = 10)
        {
            string vssDb = ConfigurationManager.ConnectionStrings["VssDb"].ConnectionString;
            Generic_JcReq = new GenericFactory<JcReqVM>();
            return Generic_JcReq.ExecuteCommandList(CommandType.StoredProcedure, StoredProcedure.sp_GetStoreReq, new Hashtable() { { "PageIndex", pageIndex }, { "PageSize", pageSize }, { "ReqStatus", reqStatus }, { "StoreTranTypeId", storeTranTypeId } }, vssDb);
        }

        public bool Add(JcReq model)
        {
            try
            {
                model.CreateDate = DateTime.Now;
                _vssDb.JcReqs.Add(model);
                _vssDb.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(JcReq model)
        {
            try
            {
                var oJcReq = _vssDb.JcReqs
                 .Where(x => x.Id == model.Id).FirstOrDefault();
                if (oJcReq != null)
                {
                    oJcReq.IsRead = model.IsRead;
                    oJcReq.ReadBy = model.ReadBy;
                    oJcReq.CreateBy = model.CreateBy;
                    oJcReq.CreateDate = DateTime.Now;
                    oJcReq.Remark = model.Remark;
                    oJcReq.Qty = model.Qty;
                    oJcReq.Brand = model.Brand;
                    oJcReq.BrandModel = model.BrandModel;
                    oJcReq.PartName = model.PartName;
                    oJcReq.PartNo = model.PartNo;
                    oJcReq.JcNo = model.JcNo;
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
            bool isSuccess = false;
            try
            {
                var oJcReq = _vssDb.JcReqs
                 .Where(x => x.Id == id)
                 .FirstOrDefault();
                if (oJcReq != null)
                {
                    _vssDb.JcReqs.Remove(oJcReq);
                    _vssDb.SaveChanges();
                    isSuccess = true;
                }
            }
            catch
            {
            }
            return isSuccess;
        }
        
    }
}