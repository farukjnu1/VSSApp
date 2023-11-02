using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;
using VSS.DA.ViewModels.Operation;

namespace VSS.API.BL.Operation
{
    public class ClientVehicleBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        List<ClientVehicleVM> listClientVehicle = null;
        ClientVehicleVM oClientVehicle = null;

        public IEnumerable<ClientVehicleVM> Get()
        {
            listClientVehicle = new List<ClientVehicleVM>();
            var listCV = _vssDb.ClientVehicles.ToList();

            foreach (ClientVehicle oCV in listCV)
            {
                ClientVehicleVM oClientVehicle = new ClientVehicleVM();
                oClientVehicle.Id = oCV.Id;
                oClientVehicle.VehicleNo = oCV.VehicleNo;
                oClientVehicle.Model = oCV.Model;
                oClientVehicle.Vin = oCV.Vin;
                oClientVehicle.ClientId = oCV.ClientId;
                listClientVehicle.Add(oClientVehicle);
            }
            return listClientVehicle;
        }

        public bool Add(ClientVehicle model)
        {
            try
            {
                //model.Id = GetNewId();
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
                var selectedClientVehicle = _vssDb.ClientVehicles
                 .Where(x => x.Id == model.Id).FirstOrDefault();
                if (selectedClientVehicle != null)
                {
                    selectedClientVehicle.Id = model.Id;
                    selectedClientVehicle.VehicleNo = model.VehicleNo;
                    selectedClientVehicle.Model = model.Model;
                    selectedClientVehicle.Vin = model.Vin;
                    selectedClientVehicle.ClientId = model.ClientId;
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
    }
}