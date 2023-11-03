using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;
using VSS.API.DA.ViewModels.Stores;

namespace VSS.API.BL.Stores
{
    public class ItemBL
    {
        ModelVssDb _vssDb = new ModelVssDb();

        public IEnumerable<ItemVM> Get(int pageIndex = 0, int pageSize = 10)
        {
            int nRow = _vssDb.Items.Count();
            var listItem = (from i in _vssDb.Items
                            join ic in _vssDb.ItemCategories on i.ItemCategoryId equals ic.Id
                            join b in _vssDb.Brands on i.BrandId equals b.Id
                            select new ItemVM
                            {
                                Id = i.Id,
                                ItemCode = i.ItemCode,
                                ItemName = i.ItemName,
                                PartNoOld = i.PartNoOld,
                                PartNoNew = i.PartNoNew,
                                Remarks = i.Remarks,
                                BrandId = i.BrandId,
                                ItemCategoryId = i.ItemCategoryId,
                                CategoryName = ic.Name,
                                BrandName = b.Name,
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

        public bool AddItem(Item model)
        {
            try
            {
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

        public bool UpdateItem(Item model)
        {
            try
            {
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

        public bool RemoveItem(int id)
        {
            try
            {
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