using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.BL.Stores;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Stores;

namespace VSS.API.Controllers
{
    public class StoreRetController : ApiController
    {
        // GET: api/StoreReq

        [HttpGet]
        public IEnumerable<StoreReqVM> Get(int reqStatus, int pi = 0, int ps = 10)
        {
            StoreReqBL _BL = new StoreReqBL();
            return _BL.Get(reqStatus, pi, ps);
        }

        // POST: api/StoreReq
        public bool Post([FromBody] StoreReq model)
        {
            StoreReqBL _BL = new StoreReqBL();
            return _BL.Add(model);
        }

        // PUT: api/StoreReq/5
        public bool Put([FromBody] StoreReq model)
        {
            StoreReqBL _BL = new StoreReqBL();
            return _BL.Update(model);
        }

        // DELETE: api/StoreReq/5
        public bool Delete(int id)
        {
            StoreReqBL _BL = new StoreReqBL();
            return _BL.Remove(id);
        }
    }
}
