﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSS.API.DA.ADO;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;
using VSS.DA.ADO;
using VSS.DA.ViewModels.Operation;

namespace VSS.BL.Operation
{
    public class ClientBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        List<ClientVM> listClient = null;
        ClientVM oClient = null;
        private IGenericFactory<ClientVM> Generic_Client = null;
        public ClientBL() { }
        public IEnumerable<ClientVM> Get(string phone, int pageIndex, int pageSize)
        {
            string vssDb = ConfigurationManager.ConnectionStrings["VssDb"].ConnectionString;
            Generic_Client = new GenericFactory<ClientVM>();
            var oHashTable = new Hashtable()
            {
                { "PageIndex", pageIndex },
                { "PageSize", pageSize },
                { "phone", phone }
            };
            return Generic_Client.ExecuteCommandList(CommandType.StoredProcedure, StoredProcedure.sp_GetClient, oHashTable, vssDb);
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
                oClient.ContactPerson = oBP.ContactPerson;
                oClient.ContactPersonNo = oBP.ContactPersonNo;
                oClient.ClientInfo = oBP.ClientInfo;
                oClient.MembershipNo = oBP.MembershipNo;
            }
            return oClient;
        }
        public IEnumerable<ClientVM> GetClient()
        {
            //oClient = new ClientVM();
            //var listClient = _vssDb.BusinessPartners
            //    .Where(x => x.BpTypeId == 1)
            //    .ToList();
            var listClient = from x in _vssDb.BusinessPartners
                             where x.BpTypeId == 1
                             select new ClientVM
                             {
                                 BpId = x.BpId,
                                 Name = x.Name
                             };
            return listClient;
        }
        public bool Add(BusinessPartner model)
        {
            try
            {
                var oClient = (from x in _vssDb.BusinessPartners where x.Phone == model.Phone.Trim() select x).FirstOrDefault();
                if (oClient == null)
                {
                    model.Phone = model.Phone.Trim();
                    model.BpId = GetNewId();
                    model.BpTypeId = 1;
                    model.CreateDate = DateTime.Now;
                    _vssDb.BusinessPartners.Add(model);
                    _vssDb.SaveChanges();
                    return true;
                }
                return false;
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
                return 1;
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
                    oBP.Phone = model.Phone.Trim();
                    oBP.Email = model.Email;
                    oBP.Address = model.Address;
                    oBP.ContactPerson = model.ContactPerson;
                    oBP.ContactPersonNo = model.ContactPersonNo;
                    oBP.ClientInfo = model.ClientInfo;
                    oBP.MembershipNo = model.MembershipNo;
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
