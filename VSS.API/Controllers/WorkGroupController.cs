using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.Attributes;
using VSS.API.BL.HR;
using VSS.API.BL.Operation;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.HR;
using VSS.API.DA.ViewModels.Operation;
using VSS.BL.Operation;

namespace VSS.API.Controllers
{
    [MyAuth]
    public class WorkGroupController : ApiController
    {
        // GET: api/WorkGroup
        public IEnumerable<WorkGroupVM> Get([FromUri] string phone, int pi = 0, int ps = 10)
        {
            WorkGroupBL _BL = new WorkGroupBL();
            return _BL.Get(phone, pi, ps);
        }

        // GET: api/WorkGroup/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/WorkGroup
        public bool Post([FromBody] WorkGroup model)
        {
            WorkGroupBL _BL = new WorkGroupBL();
            return _BL.Add(model);
        }

        // PUT: api/WorkGroup/5
        public bool Put([FromBody] WorkGroup model)
        {
            WorkGroupBL _BL = new WorkGroupBL();
            return _BL.Update(model);
        }

        // DELETE: api/WorkGroup/5
        public bool Delete(int id)
        {
            WorkGroupBL _BL = new WorkGroupBL();
            return _BL.Remove(id);
        }

        [HttpGet]
        [Route("api/WorkGroup/GetWorkGroup")]
        public IEnumerable<WorkGroupVM> GetWorkGroup()
        {
            WorkGroupBL _BL = new WorkGroupBL();
            return _BL.GetWorkGroup();
        }
    }
}
