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
        private IGenericFactory<WorkGroupVM> Generic_WorkGroupVM = null;
        private IGenericFactory<CompanyVM> Generic_CompanyVM = null;
        private IGenericFactory<JobVM> Generic_JobVM = null;
        private IGenericFactory<EngineSizeVM> Generic_EngineSizeVM = null;
        private IGenericFactory<JobGroupVM> Generic_JobGroupVM = null;
        private IGenericFactory<ItemVM> Generic_ItemVM = null;
        

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
        public List<WorkGroupVM> GetWorkGroupById(int workGroupId)
        {
            string vssDb = ConfigurationManager.ConnectionStrings["VssDb"].ConnectionString;
            Generic_WorkGroupVM = new GenericFactory<WorkGroupVM>();
            return Generic_WorkGroupVM.ExecuteCommandList(CommandType.StoredProcedure, StoredProcedure.sp_GetWorkGroupById, new Hashtable() { { "WorkGroupId", workGroupId } }, vssDb);
        }
        public CompanyVM GetCompany()
        {
            string vssDb = ConfigurationManager.ConnectionStrings["VssDb"].ConnectionString;
            Generic_CompanyVM = new GenericFactory<CompanyVM>();
            return Generic_CompanyVM.ExecuteCommandObject(CommandType.StoredProcedure, StoredProcedure.sp_GetCompany, new Hashtable() { }, vssDb);
        }
        public List<JobVM> GetJob()
        {
            string vssDb = ConfigurationManager.ConnectionStrings["VssDb"].ConnectionString;
            Generic_JobVM = new GenericFactory<JobVM>();
            return Generic_JobVM.ExecuteCommandList(CommandType.StoredProcedure, StoredProcedure.sp_GetJob, new Hashtable() { }, vssDb);
        }
        public List<EngineSizeVM> GetEngineSize()
        {
            string vssDb = ConfigurationManager.ConnectionStrings["VssDb"].ConnectionString;
            Generic_EngineSizeVM = new GenericFactory<EngineSizeVM>();
            return Generic_EngineSizeVM.ExecuteCommandList(CommandType.StoredProcedure, StoredProcedure.sp_GetEngineSize, new Hashtable() { }, vssDb);
        }
        public List<JobGroupVM> GetJobGroup()
        {
            string vssDb = ConfigurationManager.ConnectionStrings["VssDb"].ConnectionString;
            Generic_JobGroupVM = new GenericFactory<JobGroupVM>();
            return Generic_JobGroupVM.ExecuteCommandList(CommandType.StoredProcedure, StoredProcedure.sp_GetJobGroup, new Hashtable() { }, vssDb);
        }
        public List<ItemVM> GetItemByParts(string value)
        {
            string vssDb = ConfigurationManager.ConnectionStrings["VssDb"].ConnectionString;
            Generic_ItemVM = new GenericFactory<ItemVM>();
            return Generic_ItemVM.ExecuteCommandList(CommandType.StoredProcedure, StoredProcedure.sp_GetItemByParts, new Hashtable() { { "value", value } }, vssDb);
        }
    }
}