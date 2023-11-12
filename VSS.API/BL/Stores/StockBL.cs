using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Stores;

namespace VSS.API.BL.Stores
{
    public class StockBL
    {
        ModelVssDb _vssDb = null;

        public IEnumerable<StockVM> Get(string partNo, int pageIndex = 0, int pageSize = 10)
        {
            _vssDb = new ModelVssDb();
            int nRow = (from s in _vssDb.Stocks
                        join i in _vssDb.Items on s.ItemId equals i.Id
                        join b in _vssDb.Brands on i.BrandId equals b.Id
                        join bm in _vssDb.BrandModels on i.ModelId equals bm.Id
                        where i.PartNoOld == (string.IsNullOrEmpty(partNo) ? i.PartNoOld : partNo)
                        || i.PartNoNew == (string.IsNullOrEmpty(partNo) ? i.PartNoNew : partNo)
                        select s).Count();
            var listStock = (from s in _vssDb.Stocks
                            join i in _vssDb.Items on s.ItemId equals i.Id
                            join b in _vssDb.Brands on i.BrandId equals b.Id
                            join bm in _vssDb.BrandModels on i.ModelId equals bm.Id
                            join w in _vssDb.Warehouses on s.WhId equals w.Id
                            where i.PartNoOld == (string.IsNullOrEmpty(partNo) ? i.PartNoOld : partNo)
                            || i.PartNoNew == (string.IsNullOrEmpty(partNo) ? i.PartNoNew : partNo)
                            select new StockVM
                            {
                                Id = s.Id,
                                Qty = s.Qty,
                                WhId = s.WhId,
                                WhName = w.Name,
                                ItemId = i.Id,
                                ItemName = i.ItemName,
                                PartNoOld = i.PartNoOld,
                                PartNoNew = i.PartNoNew,
                                BrandName = b.Name,
                                ModelCode = bm.ModelCode,
                                PageIndex = pageIndex,
                                PageSize = pageSize,
                                RowCount = nRow
                            })
                .OrderByDescending(x => x.ItemId)
                .OrderByDescending(y => y.Id)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
            return listStock;
        }
    }
}