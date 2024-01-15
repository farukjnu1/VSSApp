using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using VSS.API.BL.Stores;
using VSS.API.DA.ADO;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.Utilities;
using VSS.API.DA.ViewModels.Billing;
using VSS.API.DA.ViewModels.Operation;
using VSS.DA.ADO;

namespace VSS.API.BL.Billing
{
    public class InvoiceBL
    {
        ModelVssDb _vssDb = null;
        private IGenericFactory<JobCardVM> Generic_JobCardVM = null;
        public bool Add(InvoiceVM model)
        {
            using (_vssDb = new ModelVssDb())
            {
                using (var _tran = _vssDb.Database.BeginTransaction())
                {
                    try
                    {
                        var oI = _vssDb.Invoices.Where(x=>x.JcId == model.JcId).FirstOrDefault();
                        if (oI != null)
                        {
                            _tran.Rollback();
                            return false;
                        }
                        else
                        {
                            #region Invoice
                            Invoice oInvoice = new Invoice();
                            oInvoice.ClientId = model.ClientId;
                            oInvoice.JcId = model.JcId;
                            oInvoice.CreateBy = model.CreateBy;
                            oInvoice.CreateDate = DateTime.Now;
                            oInvoice.GrandTotal = model.GrandTotal;
                            oInvoice.CreateBy = model.CreateBy;
                            _vssDb.Invoices.Add(oInvoice);
                            _vssDb.SaveChanges();
                            model.Id = oInvoice.Id;
                            #endregion
                            #region Invoice Item
                            var listIIRem = _vssDb.InvoiceItems.Where(x => x.InvoiceId == model.Id).ToList();
                            _vssDb.InvoiceItems.RemoveRange(listIIRem);
                            _vssDb.SaveChanges();
                            List<InvoiceItem> listInvoiceItem = new List<InvoiceItem>();
                            foreach (var oII in model.InvoiceItems)
                            {
                                InvoiceItem oInvoiceItem = new InvoiceItem();
                                oInvoiceItem.InvoiceId = model.Id;
                                oInvoiceItem.ItemId = oII.ItemId;
                                oInvoiceItem.ItemType = oII.ItemType;
                                oInvoiceItem.Qty = oII.Qty;
                                oInvoiceItem.UnitPrice = oII.UnitPrice;
                                oInvoiceItem.Tax = oII.Tax;
                                oInvoiceItem.TotalPrice = oII.TotalPrice;
                                oInvoiceItem.Discount = oII.Discount;
                                oInvoiceItem.DiscountAmount = oII.DiscountAmount;
                                oInvoiceItem.TpAfterDiscount = oII.TpAfterDiscount;
                                oInvoiceItem.Vat = oII.Vat;
                                oInvoiceItem.TotalVat = oII.TotalVat;
                                oInvoiceItem.TotalAmount = oII.TotalAmount;
                                oInvoiceItem.DoneBy = model.CreateBy;
                                oInvoiceItem.DoneDate = DateTime.Now;
                                listInvoiceItem.Add(oInvoiceItem);
                            }
                            _vssDb.InvoiceItems.AddRange(listInvoiceItem);
                            _vssDb.SaveChanges();
                            #endregion
                            _tran.Commit();
                            return true;
                        }
                    }
                    catch
                    {
                        _tran.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool Update(InvoiceVM model)
        {
            using (_vssDb = new ModelVssDb())
            {
                using (var _tran = _vssDb.Database.BeginTransaction())
                {
                    try
                    {
                        #region Validation
                        PaySettle oPaySettle = (from x in _vssDb.PaySettles where x.InvoiceId == model.Id select x).FirstOrDefault();
                        if (oPaySettle != null)
                        {
                            _tran.Rollback();
                            return false;
                        }
                        #endregion
                        var oInvoice = _vssDb.Invoices.Where(x => x.JcId == model.JcId).FirstOrDefault();
                        if (oInvoice == null)
                        {
                            _tran.Rollback();
                            return false;
                        }
                        else
                        {
                            #region Invoice
                            oInvoice.ClientId = model.ClientId;
                            oInvoice.JcId = model.JcId;
                            oInvoice.CreateBy = model.CreateBy;
                            oInvoice.CreateDate = DateTime.Now;
                            oInvoice.GrandTotal = model.GrandTotal;
                            oInvoice.CreateBy = model.CreateBy;
                            _vssDb.SaveChanges();
                            model.Id = oInvoice.Id;
                            #endregion
                            #region Invoice Item
                            var listIIRem = _vssDb.InvoiceItems.Where(x => x.InvoiceId == model.Id).ToList();
                            _vssDb.InvoiceItems.RemoveRange(listIIRem);
                            _vssDb.SaveChanges();
                            List<InvoiceItem> listInvoiceItem = new List<InvoiceItem>();
                            foreach (var oII in model.InvoiceItems)
                            {
                                InvoiceItem oInvoiceItem = new InvoiceItem();
                                oInvoiceItem.InvoiceId = model.Id;
                                oInvoiceItem.ItemId = oII.ItemId;
                                oInvoiceItem.ItemType = oII.ItemType;
                                oInvoiceItem.Qty = oII.Qty;
                                oInvoiceItem.UnitPrice = oII.UnitPrice;
                                oInvoiceItem.Tax = oII.Tax;
                                oInvoiceItem.TotalPrice = oII.TotalPrice;
                                oInvoiceItem.Discount = oII.Discount;
                                oInvoiceItem.DiscountAmount = oII.DiscountAmount;
                                oInvoiceItem.TpAfterDiscount = oII.TpAfterDiscount;
                                oInvoiceItem.Vat = oII.Vat;
                                oInvoiceItem.TotalVat = oII.TotalVat;
                                oInvoiceItem.TotalAmount = oII.TotalAmount;
                                oInvoiceItem.DoneBy = model.CreateBy;
                                oInvoiceItem.DoneDate = DateTime.Now;
                                listInvoiceItem.Add(oInvoiceItem);
                            }
                            _vssDb.InvoiceItems.AddRange(listInvoiceItem);
                            _vssDb.SaveChanges();
                            #endregion
                            _tran.Commit();
                            return true;
                        }
                    }
                    catch
                    {
                        _tran.Rollback();
                        return false;
                    }
                }
            }
        }

        public IEnumerable<JobCardVM> Get(int pageIndex = 0, int pageSize = 5, int jcStatus = 1, bool isPaid = false)
        {
            string vssDb = ConfigurationManager.ConnectionStrings["VssDb"].ConnectionString;
            Generic_JobCardVM = new GenericFactory<JobCardVM>();
            var oHashTable = new Hashtable()
            {
                { "PageIndex", pageIndex },
                { "PageSize", pageSize },
                { "JcStatus", jcStatus },
                { "IsPaid", isPaid }
            };
            return Generic_JobCardVM.ExecuteCommandList(CommandType.StoredProcedure, StoredProcedure.sp_GetJcInvoice, oHashTable, vssDb);
        }

        public InvoiceVM GetByJc([FromUri] int jcId)
        {
            _vssDb = new ModelVssDb();
            InvoiceVM oInvoice = new InvoiceVM();
            oInvoice = (from i in _vssDb.Invoices
                        join bp in _vssDb.BusinessPartners on i.ClientId equals bp.BpId
                        join cv in _vssDb.ClientVehicles on i.ClientId equals cv.ClientId
                        join jc in _vssDb.JobCards on i.JcId equals jc.Id
                        join e in _vssDb.Employees on jc.SupervisorId equals e.EmployeeId
                        where i.JcId == jcId
                        select new InvoiceVM
                        {
                            Id = i.Id,
                            JcId = jc.Id,
                            IsInvoice = i.JcId == null || i.JcId == 0 ? 0 : 1,
                            CreateBy = i.CreateBy,
                            CreateDate = i.CreateDate,
                            GrandTotal = i.GrandTotal,
                            JcNo = jc.JcNo,
                            ClientId = jc.ClientId,
                            Description = jc.ClientInfo,
                            ClientAddress = bp.Address,
                            ClientEmail = bp.Email,
                            ClientName = bp.Name,
                            ClientPhone = bp.Phone,
                            MembershipNo = bp.MembershipNo,                            
                            ContactPerson = jc.ContactPerson == null ? "" : jc.ContactPerson,
                            ContactPersonNo = jc.ContactPersonNo == null ? "" : jc.ContactPersonNo,
                            VehicleNo = cv.VehicleNo,
                            Vin = cv.Vin,
                            Model = cv.Model,
                            Supervisor = e.FirstName + " " + e.MiddleName + " " + e.LastName,
                            InvoiceItems = (from ii in _vssDb.InvoiceItems
                                            where ii.InvoiceId == i.Id
                                            select new InvoiceItemVM
                                            {
                                                Id = ii.Id,
                                                InvoiceId = ii.Id,
                                                ItemId = ii.ItemId,
                                                ItemType = ii.ItemType,
                                                Qty = ii.Qty,
                                                UnitPrice = ii.UnitPrice,
                                                Tax = ii.Tax,
                                                DoneBy = ii.DoneBy,
                                                DoneDate = ii.DoneDate,
                                                TotalPrice = ii.TotalPrice,
                                                Discount = ii.Discount,
                                                DiscountAmount = ii.DiscountAmount,
                                                TpAfterDiscount = ii.TpAfterDiscount,
                                                Vat = ii.Vat,
                                                TotalVat = ii.TotalVat,
                                                TotalAmount = ii.TotalAmount
                                            }).ToList(),
                            BalanceAmount = (from b in _vssDb.BusinessPartnerBalances where b.BusinessPartnerId == i.ClientId select b.BalanceAmount).FirstOrDefault(),
                            PaySettles = (from ps in _vssDb.PaySettles
                                          join pm in _vssDb.PayMethods on ps.PaymentMethod equals pm.MethodId
                                          where ps.InvoiceId == i.Id
                                          select new PaySettleVM()
                                          {
                                              Amount = ps.Amount,
                                              Id = ps.Id,
                                              InvoiceId = i.Id,
                                              PayDate = ps.PayDate,
                                              PaymentMethod = ps.PaymentMethod,
                                              PayMethodName = pm.Name
                                          }).ToList()
                        }).FirstOrDefault();
            oInvoice = oInvoice != null ? oInvoice : new InvoiceVM();
            oInvoice.GrandTotalWord = NumberToWord.ConvertAmount((double)oInvoice.GrandTotal);
            return oInvoice;
        }

        
    }
}