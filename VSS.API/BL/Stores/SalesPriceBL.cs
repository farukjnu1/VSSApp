using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;
using VSS.API.DA.ViewModels.Stores;

namespace VSS.API.BL.Stores
{
    public class SalesPriceBL
    {
        ModelVssDb _vssDb = null;

        public IEnumerable<SalesPriceVM> Get(string partNo,int pageIndex = 0, int pageSize = 10)
        {
            _vssDb = new ModelVssDb();
            int nRow = (from sp in _vssDb.SalesPrices
                        join i in _vssDb.Items on sp.ItemId equals i.Id
                        join b in _vssDb.Brands on i.BrandId equals b.Id
                        join bm in _vssDb.BrandModels on i.ModelId equals bm.Id
                        where i.PartNoOld == (string.IsNullOrEmpty(partNo) ? i.PartNoOld : partNo)
                        || i.PartNoNew == (string.IsNullOrEmpty(partNo) ? i.PartNoNew : partNo)
                        select sp).Count();
            var listItem = (from sp in _vssDb.SalesPrices
                            join i in _vssDb.Items on sp.ItemId equals i.Id
                            join b in _vssDb.Brands on i.BrandId equals b.Id
                            join bm in _vssDb.BrandModels on i.ModelId equals bm.Id
                            where i.PartNoOld == (string.IsNullOrEmpty(partNo) ? i.PartNoOld : partNo)
                            || i.PartNoNew == (string.IsNullOrEmpty(partNo) ? i.PartNoNew : partNo)
                            select new SalesPriceVM
                            {
                                Id = sp.Id,
                                ItemId = i.Id,
                                ItemCode = i.ItemCode,
                                ItemName = i.ItemName,
                                PartNoOld = i.PartNoOld,
                                PartNoNew = i.PartNoNew,
                                Remarks = i.Remarks,
                                BrandId = i.BrandId,
                                BrandName = b.Name,
                                ModelId = i.ModelId,
                                ModelCode = bm.ModelCode,
                                SalePrice = sp.SalePrice,
                                AvgPurchasePrice = sp.AvgPurchasePrice,
                                MinPurchasePrice = sp.MinPurchasePrice,
                                MaxPurchasePrice = sp.MaxPurchasePrice,
                                CreateDate = sp.CreateDate,
                                PageIndex = pageIndex,
                                PageSize = pageSize,
                                RowCount = nRow
                            })
                .OrderByDescending(x => x.ItemId)
                .OrderByDescending(y => y.Id)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
            return listItem;
        }

        public bool Add(SalesPriceVM model)
        {
            bool isSuccess = false;
            using (_vssDb = new ModelVssDb())
            {
                using (var _tran = _vssDb.Database.BeginTransaction())
                {
                    try
                    {
                        _vssDb = new ModelVssDb();
                        var listSalePrice = (from x in _vssDb.SalesPrices where x.ItemId == model.ItemId && x.IsActive == true select x).ToList();
                        foreach (var item in listSalePrice)
                        {
                            item.IsActive = false;
                            _vssDb.SaveChanges();
                        }
                        var oSalePrice = new SalesPrice();
                        oSalePrice.CreateDate = DateTime.Now;
                        oSalePrice.CreateBy = model.CreateBy;
                        oSalePrice.IsActive = true;
                        oSalePrice.AvgPurchasePrice = model.AvgPurchasePrice;
                        oSalePrice.MinPurchasePrice = model.MinPurchasePrice;
                        oSalePrice.MaxPurchasePrice = model.MaxPurchasePrice;
                        oSalePrice.SalePrice = model.SalePrice;
                        oSalePrice.ItemId = model.ItemId;
                        oSalePrice.Remarks = model.Remarks;
                        _vssDb.SalesPrices.Add(oSalePrice);
                        _vssDb.SaveChanges();
                        _tran.Commit();
                        isSuccess = true;
                    }
                    catch
                    {
                        _tran.Rollback();
                    }
                }
            }
            return isSuccess;
        }

        public bool Update(SalesPriceVM model)
        {
            return false;
        }

        public bool Remove(int id)
        {
            return false;
        }
    }
}