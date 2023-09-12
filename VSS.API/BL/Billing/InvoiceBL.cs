using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Billing;
using VSS.API.DA.ViewModels.Operation;

namespace VSS.API.BL.Billing
{
    public class InvoiceBL
    {
        ModelVssDb _vssDb = null;
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
                                oInvoiceItem.DoneBy = oII.DoneBy;
                                oInvoiceItem.DoneDate = DateTime.Now;
                                listInvoiceItem.Add(oInvoiceItem);
                            }
                            _vssDb.InvoiceItems.AddRange(listInvoiceItem);
                            _vssDb.SaveChanges();
                            #endregion
                        }
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