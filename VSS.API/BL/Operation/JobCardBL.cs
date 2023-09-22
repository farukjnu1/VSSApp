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
using VSS.API.DA.EF.VssDb;
using System.Resources;
using Google.Protobuf.WellKnownTypes;
using VSS.API.DA.ViewModels.Billing;

namespace VSS.API.BL.Operation
{
    public class JobCardBL
    {
        private IGenericFactory<ClientVM> Generic_T = null;
        private IGenericFactory<JobCardVM> Generic_JobCardVM = null;
        private IGenericFactory<WorkGroupVM> Generic_WorkGroupVM = null;
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

        ModelVssDb _vssDb = null;
        public bool Add(JobCardVM model)
        {
            using (_vssDb = new ModelVssDb())
            {
                using (var _tran = _vssDb.Database.BeginTransaction())
                {
                    try
                    {
                        #region Client
                        BusinessPartner oBP = null;
                        if (model.ClientId > 0)
                        {
                            oBP = _vssDb.BusinessPartners.Where(x=>x.BpId == model.ClientId).FirstOrDefault();
                            if (oBP != null)
                            {
                                oBP.BpTypeId = 1;
                                oBP.MembershipNo = model.MembershipNo;
                                oBP.Name = model.ClientName;
                                oBP.Address = model.ClientAddress;
                                oBP.CreateBy = model.CreateBy;
                                oBP.CreateDate = DateTime.Now;
                                oBP.Email = model.ClientEmail;
                                oBP.IsActive = true;
                                oBP.Phone = model.ClientPhone;                            }
                        }
                        else
                        {
                            oBP = new BusinessPartner();
                            oBP.BpTypeId = 1;
                            oBP.MembershipNo = model.MembershipNo;
                            oBP.Name = model.ClientName;
                            oBP.Address = model.ClientAddress;
                            oBP.CreateBy = model.CreateBy;
                            oBP.CreateDate = DateTime.Now;
                            oBP.Email = model.ClientEmail;
                            oBP.IsActive = true;
                            oBP.Phone = model.ClientPhone;
                            _vssDb.BusinessPartners.Add(oBP);
                        }
                        _vssDb.SaveChanges();
                        model.ClientId = oBP.BpId;
                        #endregion
                        #region Vehicle Info
                        JobCard oJobCard = new JobCard();
                        oJobCard.JcNo = model.JcNo;
                        oJobCard.VehicleNo = model.VehicleNo;
                        oJobCard.Model = model.Model;
                        oJobCard.Vin = model.Vin;
                        oJobCard.Mileage = model.Mileage;
                        oJobCard.ReceiveDate = model.ReceiveDate;
                        oJobCard.SupervisorId = model.ReceiveBy;
                        oJobCard.Bay = model.Bay;
                        oJobCard.JcStatus = model.JcStatus;
                        oJobCard.EstiCostJob = model.EstiCostJob;
                        oJobCard.EstiCostSpare = model.EstiCostSpare;
                        oJobCard.EstiCostTotal = model.EstiCostTotal;
                        oJobCard.ActualCostJob = model.ActualCostJob;
                        oJobCard.ActualCostSpare = model.ActualCostSpare;
                        oJobCard.ActualCostTotal = model.ActualCostTotal;
                        oJobCard.ClientId = model.ClientId;
                        oJobCard.ClientInfo = model.Description;
                        oJobCard.ContactPerson = model.ContactPerson;
                        oJobCard.ContactPersonNo = model.ContactPersonNo;
                        oJobCard.CreateBy = model.CreateBy;
                        oJobCard.CreateDate = DateTime.Now;
                        _vssDb.JobCards.Add(oJobCard);
                        _vssDb.SaveChanges();
                        model.Id = oJobCard.Id;
                        #endregion
                        #region Job-Details
                        var listJcJobRem = _vssDb.JcJobs.Where(x => x.JcId == model.Id).ToList();
                        _vssDb.JcJobs.RemoveRange(listJcJobRem);
                        _vssDb.SaveChanges();
                        List<JcJob> listJcJob = new List<JcJob>();
                        foreach (var jcJob in model.JobDetails)
                        {
                            JcJob oJcJob = new JcJob();
                            oJcJob.JobGroupId = jcJob.JobGroupId;
                            oJcJob.JobId = jcJob.JobId;
                            oJcJob.EngineSizeId = jcJob.EngineSizeId;
                            oJcJob.Price = jcJob.Price;
                            oJcJob.Duration = jcJob.Duration;
                            oJcJob.JobStatus = jcJob.JobStatus;
                            oJcJob.JcId = oJobCard.Id;
                            listJcJob.Add(oJcJob);
                        }
                        _vssDb.JcJobs.AddRange(listJcJob);
                        _vssDb.SaveChanges();
                        #endregion
                        #region Spare-Parts
                        var listJcSpareRe = _vssDb.JcSpares.Where(x => x.JcId == model.Id).ToList();
                        _vssDb.JcSpares.RemoveRange(listJcSpareRe);
                        _vssDb.SaveChanges();
                        List<JcSpare> listJcSpare = new List<JcSpare>();
                        foreach (var jcSpare in model.JcSpares)
                        {
                            JcSpare oJcSpare = new JcSpare();
                            oJcSpare.ItemId = jcSpare.ItemId;
                            oJcSpare.Quantity = jcSpare.Quantity;
                            oJcSpare.SalePrice = jcSpare.SalePrice;
                            oJcSpare.ItemStatus = jcSpare.ItemStatus;
                            oJcSpare.SpareAmount = jcSpare.SpareAmount;
                            oJcSpare.JcId = oJobCard.Id;
                            listJcSpare.Add(oJcSpare);
                        }
                        _vssDb.JcSpares.AddRange(listJcSpare);
                        _vssDb.SaveChanges();
                        #endregion
                        #region JC HR
                        var listJcHRRe = _vssDb.JcHRs.Where(x => x.JcId == model.Id).ToList();
                        _vssDb.JcHRs.RemoveRange(listJcHRRe);
                        _vssDb.SaveChanges();
                        List<JcHR> listJcHR = new List<JcHR>();
                        foreach (var oJcHR in model.Resources)
                        {
                            JcHR oJcHr = new JcHR();
                            oJcHr.EmployeeId = oJcHR.EmployeeId;
                            oJcHr.JcId = oJobCard.Id;
                            listJcHR.Add(oJcHr);
                        }
                        _vssDb.JcHRs.AddRange(listJcHR);
                        _vssDb.SaveChanges();
                        #endregion
                        _tran.Commit();
                        return true;
                    }
                    catch
                    {
                        _tran.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool Update(JobCardVM model)
        {
            using (_vssDb = new ModelVssDb())
            {
                using (var _tran = _vssDb.Database.BeginTransaction())
                {
                    try
                    {
                        #region Validation
                        Invoice oI = (from x in _vssDb.Invoices where x.JcId == model.Id select x).FirstOrDefault();
                        if (oI != null) 
                        {
                            _tran.Rollback();
                            return false;
                        }
                        #endregion
                        #region Client
                        BusinessPartner oBP = null;
                        if (model.ClientId > 0)
                        {
                            oBP = _vssDb.BusinessPartners.Where(x => x.BpId == model.ClientId).FirstOrDefault();
                            if (oBP != null)
                            {
                                oBP.BpTypeId = 1;
                                oBP.MembershipNo = model.MembershipNo;
                                oBP.Name = model.ClientName;
                                oBP.Address = model.ClientAddress;
                                oBP.CreateBy = model.CreateBy;
                                oBP.CreateDate = DateTime.Now;
                                oBP.Email = model.ClientEmail;
                                oBP.IsActive = true;
                                oBP.Phone = model.ClientPhone;
                            }
                        }
                        else
                        {
                            oBP = new BusinessPartner();
                            oBP.BpTypeId = 1;
                            oBP.MembershipNo = model.MembershipNo;
                            oBP.Name = model.ClientName;
                            oBP.Address = model.ClientAddress;
                            oBP.CreateBy = model.CreateBy;
                            oBP.CreateDate = DateTime.Now;
                            oBP.Email = model.ClientEmail;
                            oBP.IsActive = true;
                            oBP.Phone = model.ClientPhone;
                            _vssDb.BusinessPartners.Add(oBP);
                        }
                        _vssDb.SaveChanges();
                        model.ClientId = oBP.BpId;
                        #endregion
                        #region Vehicle Info
                        JobCard oJobCard = (from x in _vssDb.JobCards where x.Id == model.Id select x).FirstOrDefault();
                        if (oJobCard != null)
                        {
                            oJobCard.JcNo = model.JcNo;
                            oJobCard.VehicleNo = model.VehicleNo;
                            oJobCard.Model = model.Model;
                            oJobCard.Vin = model.Vin;
                            oJobCard.Mileage = model.Mileage;
                            oJobCard.ReceiveDate = model.ReceiveDate;
                            oJobCard.SupervisorId = model.ReceiveBy;
                            oJobCard.Bay = model.Bay;
                            oJobCard.JcStatus = model.JcStatus;
                            oJobCard.EstiCostJob = model.EstiCostJob;
                            oJobCard.EstiCostSpare = model.EstiCostSpare;
                            oJobCard.EstiCostTotal = model.EstiCostTotal;
                            oJobCard.ActualCostJob = model.ActualCostJob;
                            oJobCard.ActualCostSpare = model.ActualCostSpare;
                            oJobCard.ActualCostTotal = model.ActualCostTotal;
                            oJobCard.ClientId = model.ClientId;
                            oJobCard.ClientInfo = model.Description;
                            oJobCard.ContactPerson = model.ContactPerson;
                            oJobCard.ContactPersonNo = model.ContactPersonNo;
                            oJobCard.UpdateBy = model.CreateBy;
                            oJobCard.UpdateDate = DateTime.Now;
                            _vssDb.SaveChanges();
                        }
                        #endregion
                        #region Job-Details
                        var listJcJobRem = _vssDb.JcJobs.Where(x => x.JcId == model.Id).ToList();
                        _vssDb.JcJobs.RemoveRange(listJcJobRem);
                        _vssDb.SaveChanges();
                        List<JcJob> listJcJob = new List<JcJob>();
                        foreach (var jcJob in model.JobDetails)
                        {
                            JcJob oJcJob = new JcJob();
                            oJcJob.JobGroupId = jcJob.JobGroupId;
                            oJcJob.JobId = jcJob.JobId;
                            oJcJob.EngineSizeId = jcJob.EngineSizeId;
                            oJcJob.Price = jcJob.Price;
                            oJcJob.Duration = jcJob.Duration;
                            oJcJob.JobStatus = jcJob.JobStatus;
                            oJcJob.JcId = oJobCard.Id;
                            listJcJob.Add(oJcJob);
                        }
                        _vssDb.JcJobs.AddRange(listJcJob);
                        _vssDb.SaveChanges();
                        #endregion
                        #region Spare-Parts
                        var listJcSpareRe = _vssDb.JcSpares.Where(x => x.JcId == model.Id).ToList();
                        _vssDb.JcSpares.RemoveRange(listJcSpareRe);
                        _vssDb.SaveChanges();
                        List<JcSpare> listJcSpare = new List<JcSpare>();
                        foreach (var jcSpare in model.JcSpares)
                        {
                            JcSpare oJcSpare = new JcSpare();
                            oJcSpare.ItemId = jcSpare.ItemId;
                            oJcSpare.Quantity = jcSpare.Quantity;
                            oJcSpare.SalePrice = jcSpare.SalePrice;
                            oJcSpare.ItemStatus = jcSpare.ItemStatus;
                            oJcSpare.SpareAmount = jcSpare.SpareAmount;
                            oJcSpare.JcId = oJobCard.Id;
                            listJcSpare.Add(oJcSpare);
                        }
                        _vssDb.JcSpares.AddRange(listJcSpare);
                        _vssDb.SaveChanges();
                        #endregion
                        #region JC HR
                        var listJcHRRe = _vssDb.JcHRs.Where(x => x.JcId == model.Id).ToList();
                        _vssDb.JcHRs.RemoveRange(listJcHRRe);
                        _vssDb.SaveChanges();
                        List<JcHR> listJcHR = new List<JcHR>();
                        foreach (var oJcHR in model.Resources)
                        {
                            JcHR oJcHr = new JcHR();
                            oJcHr.EmployeeId = oJcHR.EmployeeId;
                            oJcHr.JcId = oJobCard.Id;
                            listJcHR.Add(oJcHr);
                        }
                        _vssDb.JcHRs.AddRange(listJcHR);
                        _vssDb.SaveChanges();
                        #endregion
                        _tran.Commit();
                        return true;
                    }
                    catch
                    {
                        _tran.Rollback();
                        return false;
                    }
                }
            }
        }

        public IEnumerable<JobCardVM> Get(int pageIndex = 0, int pageSize = 5, int jcStatus = 0)
        {
            string vssDb = ConfigurationManager.ConnectionStrings["VssDb"].ConnectionString;
            Generic_JobCardVM = new GenericFactory<JobCardVM>();
            var oHashTable = new Hashtable()
            {
                { "PageIndex", pageIndex },
                { "PageSize", pageSize },
                { "JcStatus", jcStatus }
            };
            return Generic_JobCardVM.ExecuteCommandList(CommandType.StoredProcedure, StoredProcedure.sp_GetJobCard, oHashTable, vssDb);
        }

        public JobCardVM Get(int id)
        {
            _vssDb = new ModelVssDb();
            var oI = _vssDb.Invoices.Where(x=>x.JcId == id).FirstOrDefault();
            int isInvoice = oI == null ? 0 : 1;
            long invoiceId = oI == null ? 0 : oI.Id;
            JobCardVM oJobCard = null;
            oJobCard = (from jc in _vssDb.JobCards
                        join bp in _vssDb.BusinessPartners on jc.ClientId equals bp.BpId
                        where jc.Id == id
                        select new JobCardVM
                        {
                            Id = jc.Id,
                            JcNo = jc.JcNo,
                            IsInvoice = isInvoice,
                            VehicleNo = jc.VehicleNo,
                            Model = jc.Model,
                            Vin = jc.Vin,
                            Mileage = jc.Mileage,
                            ReceiveDate = jc.ReceiveDate,
                            ReceiveBy = jc.SupervisorId,
                            Bay = jc.Bay,
                            JcStatus = jc.JcStatus,
                            EstiCostJob = jc.EstiCostJob,
                            EstiCostSpare = jc.EstiCostSpare,
                            EstiCostTotal = jc.EstiCostTotal,
                            ActualCostJob = jc.ActualCostJob,
                            ActualCostSpare = jc.ActualCostSpare,
                            ActualCostTotal = jc.ActualCostTotal,
                            ClientId = jc.ClientId,
                            Description = jc.ClientInfo,
                            CreateBy = jc.CreateBy,
                            CreateDate = jc.CreateDate,
                            ClientAddress = bp.Address,
                            ClientEmail = bp.Email,
                            ClientName = bp.Name,
                            ClientPhone = bp.Phone,
                            MembershipNo = bp.MembershipNo,
                            ContactPerson = jc.ContactPerson,
                            ContactPersonNo = jc.ContactPersonNo,
                            UpdateDate = jc.UpdateDate,
                            JobDetails = (from j in _vssDb.JcJobs
                                          join jg in _vssDb.JobGroups on j.JobGroupId equals jg.GroupId
                                          join es in _vssDb.EngineSizes on j.EngineSizeId equals es.EngineSizeId
                                          join jj in _vssDb.Jobs on j.JobId equals jj.JobId
                                          where j.JcId == jc.Id
                                          select new JobDetailVm
                                          {
                                              Id = j.Id,
                                              JobId = j.JobId,
                                              JobStatus = j.JobStatus,
                                              JcId = jc.Id,
                                              Duration = j.Duration,
                                              JobGroupId = j.JobGroupId,
                                              JobGroupName = jg.Name,
                                              EngineSizeId = j.EngineSizeId,
                                              EngineSizeName = es.CC,
                                              JobStatusName = j.JobStatus == 1 ? "Close" : j.JobStatus == 2 ? "Open" : "",
                                              JobName = jj.Description,
                                              Price = j.Price
                                          }).ToList(),
                            JcSpares = (from s in _vssDb.JcSpares
                                        join i in _vssDb.Items on s.ItemId equals i.Id
                                        join b in _vssDb.Brands on i.BrandId equals b.Id
                                        where s.JcId == jc.Id
                                        select new JcSpareVm
                                        {
                                            Id = s.Id,
                                            JcId = jc.Id,
                                            ItemId = i.Id,
                                            ItemCode = i.ItemCode,
                                            ItemName = i.ItemName,
                                            BrandId = i.BrandId,
                                            BrandName = b.Name,
                                            SalePrice = s.SalePrice,
                                            Quantity = s.Quantity,
                                            SpareAmount = s.SpareAmount,
                                            ItemStatus = s.ItemStatus,
                                            ItemStatusName = s.ItemStatus == 1 ? "Used" : "Refund"
                                        }).ToList(),
                            Resources = (from hr in _vssDb.JcHRs
                                         join e in _vssDb.Employees on hr.EmployeeId equals e.EmployeeId
                                         where hr.JcId == jc.Id
                                         select new JcHRVM
                                         {
                                             Id = hr.Id,
                                             JcId = jc.Id,
                                             EmployeeId = hr.EmployeeId,
                                             FullName = e.FirstName + " " + e.MiddleName + " " + e.LastName
                                         }).ToList(),
                            BalanceAmount = (from b in _vssDb.BusinessPartnerBalances where b.BusinessPartnerId == jc.ClientId select b.BalanceAmount).FirstOrDefault(),
                            PaySettles = (from ps in _vssDb.PaySettles
                                          join pm in _vssDb.PayMethods on ps.PaymentMethod equals pm.MethodId
                                          where ps.InvoiceId == invoiceId
                                          select new PaySettleVM()
                                          {
                                              Amount = ps.Amount,
                                              Id = ps.Id,
                                              InvoiceId = invoiceId,
                                              PayDate = ps.PayDate,
                                              PaymentMethod = ps.PaymentMethod,
                                              PayMethodName = pm.Name
                                          }).ToList()
                        }).FirstOrDefault();
            if (oJobCard != null)
            {
                var oUser = (from u in _vssDb.Users where u.UserID == oJobCard.CreateBy select u).FirstOrDefault();
                if (oUser != null) 
                {
                    oJobCard.CreateByName = oUser != null ? oUser.FirstName + " " + oUser.MiddleName + " " + oUser.LastName : "";
                }
            }
            return oJobCard;
        }
    }
}