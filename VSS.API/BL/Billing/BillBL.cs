using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;

namespace VSS.API.BL.Billing
{
    public class BillBL
    {
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
    }
}