using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.Attributes;
using VSS.API.BL.Stores;
using VSS.API.DA.ViewModels.Stores;

namespace VSS.API.Controllers
{
    //[MyAuth]
    public class WarehouseController : ApiController
    {
        // GET: api/Warehouse
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
        public void Put(int id, [FromBody]string value)
        {
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
