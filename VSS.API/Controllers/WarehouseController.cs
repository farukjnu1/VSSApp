using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.Attributes;
using VSS.API.BL.Stores;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;
using VSS.API.DA.ViewModels.Stores;
using VSS.BL.Operation;

namespace VSS.API.Controllers
{
    [MyAuth]
    public class WarehouseController : ApiController
    {
        // GET: api/Warehouse
        public IEnumerable<WarehouseVM> Get(int pi = 0, int ps = 5)
        {
            WarehouseBL _BL = new WarehouseBL();
            return _BL.Get(pi, ps);
        }

        // GET: api/Warehouse/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Warehouse
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Warehouse/5
        public bool Put([FromBody] Warehouse model)
        {
            WarehouseBL _BL = new WarehouseBL();
            return _BL.Update(model);
        }

        // DELETE: api/Warehouse/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("api/WareHouse/getWareHouse")]
        public IEnumerable<WarehouseVM> getWareHouse()
        {
            WarehouseBL _BL = new WarehouseBL();
            return _BL.GetWarehouse();
        }
    }
}
