using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.BL.Operation;
using VSS.DA.EF.VssDb;

namespace VSS.API.Controllers
{
    public class JobGroupController : ApiController
    {
        // GET: api/JobGroup
        public IEnumerable<JobGroup> Get()
        {
            JobGroupBL _BL = new JobGroupBL();
            return _BL.Get();
        }

        // GET: api/JobGroup/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/JobGroup
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/JobGroup/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/JobGroup/5
        public void Delete(int id)
        {
        }
    }
}
