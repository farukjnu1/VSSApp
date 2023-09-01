using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.DA.EF.VssDb;
using VSS.BL.Operation;
using VSS.DA.EF.VssDb;

namespace VSS.API.Controllers
{
    public class EngineSizeController : ApiController
    {
        // GET: api/EngineSize
        public IEnumerable<EngineSize> Get()
        {
            EngineSizeBL _BL = new EngineSizeBL();
            return _BL.Get();
        }

        // GET: api/EngineSize/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EngineSize
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EngineSize/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EngineSize/5
        public void Delete(int id)
        {
        }
    }
}
