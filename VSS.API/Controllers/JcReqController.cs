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
    public class JcReqController : ApiController
    {
        // GET: api/JcReq
        [HttpGet]
        public IEnumerable<JcReqVM> Get(int pi = 0, int ps = 10)
        {
            JcReqBL _BL = new JcReqBL();
            return _BL.Get(pi, ps);
        }

        // POST: api/StoreReq
        public bool Post([FromBody] JcReq model)
        {
            JcReqBL _BL = new JcReqBL();
            return _BL.Add(model);
        }

        // PUT: api/StoreReq/5
        public bool Put([FromBody] JcReq model)
        {
            JcReqBL _BL = new JcReqBL();
            return _BL.Update(model);
        }

        // DELETE: api/StoreReq/5
        public bool Delete(int id)
        {
            JcReqBL _BL = new JcReqBL();
            return _BL.Remove(id);
        }
    }
}
