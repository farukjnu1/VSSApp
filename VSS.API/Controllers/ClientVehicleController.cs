using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VSS.API.Attributes;
using VSS.API.BL.Operation;
using VSS.API.BL.Stores;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;
using VSS.BL.Operation;
using VSS.DA.ViewModels.Operation;

namespace VSS.API.Controllers
{
    [MyAuth]
    public class ClientVehicleController : ApiController
    {
        // GET: api/ClientVehicle
        public IEnumerable<ClientVehicleVM> Get([FromUri] string phone, string vehicle, int pi = 0, int ps = 10)
        {
            ClientVehicleBL _BL = new ClientVehicleBL();
            return _BL.Get(phone, vehicle, pi, ps);
        }

        public ClientVehicleVM GetById(long id)
        {
            ClientVehicleBL _BL = new ClientVehicleBL();
            return _BL.Get(id);
        }

        // POST: api/ClientVehicle
        public bool Post([FromBody] ClientVehicle model)
        {
            ClientVehicleBL _BL = new ClientVehicleBL();
            return _BL.Add(model);
        }

        // PUT: api/ClientVehicle/5
        public bool Put([FromBody] ClientVehicle model)
        {
            ClientVehicleBL _BL = new ClientVehicleBL();
            return _BL.Update(model);
        }

        [HttpGet]
        [Route("api/ClientVehicle/GetVehiclesByClient")]
        public IEnumerable<ClientVehicleVM> GetVehiclesByClient(long id)
        {
            ClientVehicleBL _BL = new ClientVehicleBL();
            return _BL.GetVehiclesByClient(id);
        }

    }
}
