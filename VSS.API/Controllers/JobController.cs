using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.Attributes;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;
using VSS.BL.Operation;

namespace VSS.API.Controllers
{
    //[MyAuth]
    public class JobController : ApiController
    {
        // GET: api/Job
        public IEnumerable<JobVM> Get(int pi = 0, int ps = 10)
        {
            JobBL _BL = new JobBL();
            return _BL.Get(pi, ps);
        }

        // GET: api/Job/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Job
        public bool Post([FromBody] Job model)
        {
            JobBL _BL = new JobBL();
            return _BL.AddJob(model);
        }

        // PUT: api/Job/5
        public bool Put([FromBody] Job model)
        {
            JobBL _BL = new JobBL();
            return _BL.UpdateJob(model);
        }

        // DELETE: api/Job/5
        public bool Delete(int id)
        {
            JobBL _BL = new JobBL();
            return _BL.RemoveJob(id);
        }
    }
}
