using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;
using VSS.BL.Operation;
using VSS.DA.EF.VssDb;

namespace VSS.API.Controllers
{
    public class JobGroupController : ApiController
    {
        // GET: api/JobGroup
        public IEnumerable<JobGroupVM> Get(int pi = 0, int ps = 10)
        {
            JobGroupBL _BL = new JobGroupBL();
            return _BL.Get(pi, ps);
        }

        // GET: api/JobGroup/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/JobGroup
        public bool Post([FromBody] JobGroup model)
        {
            JobGroupBL _BL = new JobGroupBL();
            return _BL.AddJobGroup(model);
        }

        // PUT: api/JobGroup/5
        public bool Put([FromBody] JobGroup model)
        {
            JobGroupBL _BL = new JobGroupBL();
            return _BL.UpdateJobGroup(model);
        }

        // DELETE: api/JobGroup/5
        public bool Delete(int id)
        {
            JobGroupBL _BL = new JobGroupBL();
            return _BL.RemoveJobGroup(id);
        }
    }
}
