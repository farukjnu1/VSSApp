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
        // GET: ClientVehicle
        public IEnumerable<ClientVehicleVM> Get()
        {
            ClientVehicleBL _BL = new ClientVehicleBL();
            return _BL.Get();
        }

    }
}
