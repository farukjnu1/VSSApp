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

        public IEnumerable<ItemVM> Get(string partNo,int pageIndex = 0, int pageSize = 10)
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
                                Id = i.Id,
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
                                PageIndex = pageIndex,
                                PageSize = pageSize,
                                RowCount = nRow
                            })
                .OrderByDescending(s => s.ItemCode)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
            return listItem;
        }

        public bool Add(Item model)
        {
            try
            {
                _vssDb = new ModelVssDb();
                model.CreateAt = DateTime.Now;
                model.CreateBy = model.CreateBy;
                model.IsActive = true;
                _vssDb.Items.Add(model);
                _vssDb.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Item model)
        {
            try
            {
                _vssDb = new ModelVssDb();
                model.UpdateBy = model.CreateBy;
                model.UpdateAt = DateTime.Now;
                model.IsActive = true;
                var oItem = _vssDb.Items
                 .Where(x => x.Id == model.Id).FirstOrDefault();
                if (oItem != null)
                {
                    oItem.ItemCode = model.ItemCode;
                    oItem.ItemName = model.ItemName;
                    oItem.PartNoOld = model.PartNoOld;
                    oItem.PartNoNew = model.PartNoNew;
                    oItem.Remarks = model.Remarks;
                    oItem.UpdateAt = DateTime.Now;
                    oItem.UpdateBy = model.UpdateBy;
                    oItem.BrandId = model.BrandId;
                    oItem.ModelId = model.ModelId;
                    oItem.ItemCategoryId = model.ItemCategoryId;
                    oItem.IsActive = true;
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
            try
            {
                _vssDb = new ModelVssDb();
                var selectedItem = _vssDb.Items
                 .Where(x => x.Id == id)
                 .FirstOrDefault();
                if (selectedItem != null)
                {
                    _vssDb.Items.Remove(selectedItem);
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

        public IEnumerable<ItemVM> getItemName()
        {
            _vssDb = new ModelVssDb();
            var listItemName = _vssDb.Items
                .Select(x => new ItemVM
                {
                    Id = x.Id,
                    ItemName = x.ItemName
                }).OrderBy(s => s.ItemName).ToList();
            return listItemName;
        }
    }
}