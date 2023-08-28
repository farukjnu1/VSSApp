using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.BL.Operation;
using VSS.API.DA.ViewModels.Operation;

namespace VSS.API.Controllers
{
    public class JobCardController : ApiController
    {
        // GET: api/JobCard
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/JobCard/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/JobCard
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/JobCard/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/JobCard/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("api/JobCard/GetJCNo")]
        public string GetJCNo()
        {
            JobCardBL jobCardBL = new JobCardBL();
            return jobCardBL.GetJCNo();
        }

        [HttpGet]
        [Route("api/JobCard/GetByVehicleNo")]
        public List<JobCardVM> GetByVehicleNo([FromUri] string vehicleno)
        {
            JobCardBL jobCardBL = new JobCardBL();
            return jobCardBL.GetByVehicleNo(vehicleno);
        }

    }
}
