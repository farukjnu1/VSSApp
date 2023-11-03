using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VSS.API.DA.ADO
{
    public class StoredProcedure
    {
        //Operation       
        public const string sp_GetJobCardNo = "[dbo].[sp_GetJobCardNo]";
        public const string sp_GetByVehicleNo = "[dbo].[sp_GetByVehicleNo]";
        public const string sp_GetWorkGroupById = "[dbo].[sp_GetWorkGroupById]";
        public const string sp_GetCompany = "[dbo].[sp_GetCompany]";
        public const string sp_GetJob = "[dbo].[sp_GetJob]";
        public const string sp_GetEngineSize = "[dbo].[sp_GetEngineSize]";
        public const string sp_GetJobGroup = "[dbo].[sp_GetJobGroup]";
        public const string sp_GetItemByParts = "[dbo].[sp_GetItemByParts]";
        public const string sp_GetClinetByPhone = "[dbo].[sp_GetClinetByPhone]";
        public const string sp_GetJobCard = "[dbo].[sp_GetJobCard]";
        public const string sp_GetUserRole = "[dbo].[sp_GetUserRole]";
        public const string sp_GetJcInvoice = "[dbo].[sp_GetJcInvoice]";
        public const string sp_GetMenuPermission = "[dbo].[sp_GetMenuPermission]";
        public const string sp_GetMenuPermissionByUserId = "[dbo].[sp_GetMenuPermissionByUserId]";
    }
}