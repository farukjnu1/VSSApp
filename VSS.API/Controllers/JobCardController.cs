using Google.Protobuf.WellKnownTypes;
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

        [HttpGet]
        [Route("api/JobCard/GetWorkGroupById")]
        public List<WorkGroupVM> GetWorkGroupById([FromUri] int workGroupId)
        {
            JobCardBL jobCardBL = new JobCardBL();
            return jobCardBL.GetWorkGroupById(workGroupId);
        }

        [HttpGet]
        [Route("api/JobCard/GetCompany")]
        public CompanyVM GetCompany()
        {
            JobCardBL jobCardBL = new JobCardBL();
            return jobCardBL.GetCompany();
        }

        [HttpGet]
        [Route("api/JobCard/GetJob")]
        public List<JobVM> GetJob()
        {
            JobCardBL jobCardBL = new JobCardBL();
            return jobCardBL.GetJob();
        }

        [HttpGet]
        [Route("api/JobCard/GetEngineSize")]
        public List<EngineSizeVM> GetEngineSize()
        {
            JobCardBL jobCardBL = new JobCardBL();
            return jobCardBL.GetEngineSize();
        }

        [HttpGet]
        [Route("api/JobCard/GetJobGroup")]
        public List<JobGroupVM> GetJobGroup()
        {
            JobCardBL jobCardBL = new JobCardBL();
            return jobCardBL.GetJobGroup();
        }

        [HttpGet]
        [Route("api/JobCard/GetItemByParts")]
        public List<ItemVM> GetItemByParts([FromUri] string value)
        {
            JobCardBL jobCardBL = new JobCardBL();
            return jobCardBL.GetItemByParts(value);
        }

    }
}
