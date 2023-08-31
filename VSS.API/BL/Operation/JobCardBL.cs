using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using VSS.API.DA.ADO;
using VSS.DA.ADO;
using VSS.DA.ViewModels.Operation;
using System.Data;
using System.Collections;
using VSS.API.DA.ViewModels.Operation;

namespace VSS.API.BL.Operation
{
    public class JobCardBL
    {
        private IGenericFactory<ClientVM> Generic_T = null;
        private IGenericFactory<JobCardVM> Generic_JobCardVM = null;
        private IGenericFactory<VehicleReceiverVM> Generic_VehicleReceiverVM = null;
        private IGenericFactory<CompanyVM> Generic_CompanyVM = null;
        //VehicleReceiverVM
        public string GetJCNo() 
        {
            string vssDb = ConfigurationManager.ConnectionStrings["VssDb"].ConnectionString;
            Generic_T = new GenericFactory<ClientVM>();
            return Generic_T.ExecuteCommandStr(CommandType.StoredProcedure, StoredProcedure.sp_GetJobCardNo, new Hashtable(), vssDb);
        }
        public List<JobCardVM> GetByVehicleNo(string vehicleNo)
        {
            string vssDb = ConfigurationManager.ConnectionStrings["VssDb"].ConnectionString;
            Generic_JobCardVM = new GenericFactory<JobCardVM>();
            return Generic_JobCardVM.ExecuteCommandList(CommandType.StoredProcedure, StoredProcedure.sp_GetByVehicleNo, new Hashtable() { { "vehicleno", vehicleNo } }, vssDb);
        }
        public List<VehicleReceiverVM> GetVehicleReceiver()
        {
            string vssDb = ConfigurationManager.ConnectionStrings["VssDb"].ConnectionString;
            Generic_VehicleReceiverVM = new GenericFactory<VehicleReceiverVM>();
            return Generic_VehicleReceiverVM.ExecuteCommandList(CommandType.StoredProcedure, StoredProcedure.sp_GetVehicleReceiver, new Hashtable() { }, vssDb);
        }
        public CompanyVM GetCompany()
        {
            string vssDb = ConfigurationManager.ConnectionStrings["VssDb"].ConnectionString;
            Generic_CompanyVM = new GenericFactory<CompanyVM>();
            return Generic_CompanyVM.ExecuteCommandObject(CommandType.StoredProcedure, StoredProcedure.sp_GetCompany, new Hashtable() { }, vssDb);
        }
    }
}