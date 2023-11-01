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
    }
}