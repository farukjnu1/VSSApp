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
            var listItem = _vssDb.Items
                .Select(x => new ItemVM
                {
                    Id = x.Id,
                    ItemCode = x.ItemCode,
                    ItemName = x.ItemName,
                    BrandId = x.BrandId,
                    PartNoOld = x.PartNoOld,
                    PartNoNew = x.PartNoNew,
                    Remarks = x.Remarks,
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
                model.UpdateAt = DateTime.Now;
                model.IsActive = true;
                var selectedItem = _vssDb.Items
                 .Where(x => x.Id == model.Id).FirstOrDefault();
                if (selectedItem != null)
                {
                    selectedItem.ItemCode = model.ItemCode;
                    selectedItem.ItemName = model.ItemName;
                    selectedItem.BrandId = model.BrandId;
                    selectedItem.PartNoOld = model.PartNoOld;
                    selectedItem.PartNoNew = model.PartNoNew;
                    selectedItem.Remarks = model.Remarks;
                    selectedItem.UpdateAt = DateTime.Now;
                    selectedItem.UpdateBy = model.UpdateBy;
                    selectedItem.IsActive = true;
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