using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using VSS.API.DA.ADO;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;
using VSS.DA.ADO;
using VSS.DA.ViewModels.Operation;

namespace VSS.API.BL.Operation
{
    public class ClientVehicleBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        List<ClientVehicleVM> listClientVehicle = null;
        ClientVehicleVM oClientVehicle = null;
        private IGenericFactory<ClientVehicleVM> Generic_ClientVehicle = null;

        public IEnumerable<ClientVehicleVM> Get(string phone, string vehicle, int pageIndex, int pageSize)
        {
            string vssDb = ConfigurationManager.ConnectionStrings["VssDb"].ConnectionString;
            Generic_ClientVehicle = new GenericFactory<ClientVehicleVM>();
            var oHashTable = new Hashtable()
            {
                { "PageIndex", pageIndex },
                { "PageSize", pageSize },
                { "phone", phone },
                { "vehicle", vehicle }
            };
            return Generic_ClientVehicle.ExecuteCommandList(CommandType.StoredProcedure, StoredProcedure.sp_GetClientVehicle, oHashTable, vssDb);
        }

        public ClientVehicleVM Get(long id)
        {
            listClientVehicle = new List<ClientVehicleVM>();
            var oCV = (from x in _vssDb.ClientVehicles
                       where x.Id == id
                       select new ClientVehicleVM
                       {
                           Id = x.Id,
                           VehicleNo = x.VehicleNo,
                           Model = x.Model,
                           Vin = x.Vin,
                           ClientId = x.ClientId,
                       }).FirstOrDefault();
            return oCV;
        }

        public bool Add(ClientVehicle model)
        {
            try
            {
                model.CreateBy = model.CreateBy;
                model.CreateDate = DateTime.Now;
                _vssDb.ClientVehicles.Add(model);
                _vssDb.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(ClientVehicle model)
        {
            try
            {
                var oClientVehicle = _vssDb.ClientVehicles
                 .Where(x => x.Id == model.Id).FirstOrDefault();
                if (oClientVehicle != null)
                {
                    oClientVehicle.Id = model.Id;
                    oClientVehicle.VehicleNo = model.VehicleNo;
                    oClientVehicle.Model = model.Model;
                    oClientVehicle.Vin = model.Vin;
                    oClientVehicle.ClientId = model.ClientId;
                    oClientVehicle.CreateBy = model.CreateBy;
                    oClientVehicle.CreateDate = DateTime.Now;
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

        public List<ClientVehicleVM> GetVehiclesByClient(long id)
        {
            listClientVehicle = new List<ClientVehicleVM>();
            var listCV = (from x in _vssDb.ClientVehicles
                       where x.ClientId == id
                       select new ClientVehicleVM
                       {
                           Id = x.Id,
                           VehicleNo = x.VehicleNo,
                           Model = x.Model,
                           Vin = x.Vin,
                           ClientId = x.ClientId,
                       }).ToList();
            return listCV;
        }

    }
}