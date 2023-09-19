using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;
using VSS.DA.ViewModels.Operation;

namespace VSS.BL.Operation
{
    public class ClientBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        List<ClientVM> listClient = null;
        ClientVM oClient = null;
        public ClientBL() { }
        public IEnumerable<ClientVM> Get()
        {
            listClient = new List<ClientVM>();
            var listBP = _vssDb.BusinessPartners
                .Where(x => x.BpTypeId == 1)
                .ToList();
            foreach (BusinessPartner oBP in listBP) 
            {
                ClientVM oClient = new ClientVM();
                oClient.BpId = oBP.BpId;
                oClient.BpTypeId = oBP.BpTypeId;
                oClient.Name = oBP.Name;
                oClient.Phone = oBP.Phone;
                oClient.Email = oBP.Email;
                oClient.Address = oBP.Address;
                listClient.Add(oClient);
            }
            return listClient;
        }
        public ClientVM Get(int id)
        {
            oClient = new ClientVM();
            var oBP = _vssDb.BusinessPartners
                .Where(x => x.BpTypeId == 1 && x.BpId == id)
                .FirstOrDefault();
            if (oBP != null)
            {
                oClient.BpId = oBP.BpId;
                oClient.BpTypeId = oBP.BpTypeId;
                oClient.Name = oBP.Name;
                oClient.Phone = oBP.Phone;
                oClient.Email = oBP.Email;
                oClient.Address = oBP.Address;
            }
            return oClient;
        }
        public bool Add(BusinessPartner model)
        {
            try
            {
                model.BpId = GetNewId();
                model.BpTypeId = 1;
                model.CreateDate = DateTime.Now;
                _vssDb.BusinessPartners.Add(model);
                _vssDb.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private int GetNewId()
        {
            try
            {
                var nid = Convert.ToInt32(_vssDb.BusinessPartners.Max(x => x.BpId)) + 1;
                return nid;
            }
            catch
            {
                return 0;
            }
        }
        public bool Update(BusinessPartner model)
        {
            try
            {
                var oBP = _vssDb.BusinessPartners
                 .Where(x => x.BpTypeId == 1 && x.BpId == model.BpId)
                 .FirstOrDefault();
                if (oBP != null)
                {
                    oBP.BpTypeId = model.BpTypeId;
                    oBP.Name = model.Name;
                    oBP.Phone = model.Phone;
                    oBP.Email = model.Email;
                    oBP.Address = model.Address;
                    oBP.UpdateBy = model.UpdateBy;
                    oBP.UpdateDate = DateTime.Now;
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
                var oBP = _vssDb.BusinessPartners
                 .Where(x => x.BpTypeId == 1 && x.BpId == id)
                 .FirstOrDefault();
                if (oBP != null)
                {
                    _vssDb.BusinessPartners.Remove(oBP);
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

        /* public IEnumerable<ClientVM> getSName()
         {
             var listName = _vssDb.BusinessPartners
                 .Select(x => new ClientVM
                 {
                     BpId = x.BpId,
                     Name = x.Name
                 }).OrderBy(s => s.Name).ToList();
             return listName;
         }*/

        public IEnumerable<ClientVM> getSName()
        {
            listClient = new List<ClientVM>();
            var listBP = _vssDb.BusinessPartners
                .Where(x => x.BpTypeId == 2)
                .ToList();
            foreach (BusinessPartner oBP in listBP)
            {
                ClientVM oClient = new ClientVM();
                oClient.BpId = oBP.BpId;
                oClient.BpTypeId = oBP.BpTypeId;
                oClient.Name = oBP.Name;
                oClient.Phone = oBP.Phone;
                oClient.Email = oBP.Email;
                oClient.Address = oBP.Address;
                listClient.Add(oClient);
            }
            return listClient;
        }
    }
}
