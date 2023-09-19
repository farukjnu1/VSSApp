using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.Attributes;
using VSS.API.BL.Operation;
using VSS.API.BL.System;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;
using VSS.API.DA.ViewModels.System;
using VSS.BL.Operation;
using ZstdSharp.Unsafe;

namespace VSS.API.Controllers
{
    [MyAuth]
    public class JobCardController : ApiController
    {
        JobCardBL _BL = null;
        CompanyBL _BLCompany = null;
        // GET: api/JobCard/5
        public IEnumerable<JobCardVM> Get(int pi = 0, int ps = 5, int jcStatus = 0)
        {
            _BL = new JobCardBL();
            return _BL.Get(pi, ps, jcStatus);
        }

        // GET: api/JobGroup/5
        public JobCardVM Get(int id)
        {
            _BL = new JobCardBL();
            return _BL.Get(id);
        }

        // POST: api/JobCard
        public bool Post([FromBody]JobCardVM model)
        {
            _BL = new JobCardBL();
            return _BL.Add(model);
        }

        // PUT: api/JobCard/5
        public bool Put([FromBody] JobCardVM model)
        {
            _BL = new JobCardBL();
            return _BL.Update(model);
        }

        // DELETE: api/JobCard/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("api/JobCard/GetJCNo")]
        public string GetJCNo()
        {
            _BL = new JobCardBL();
            return _BL.GetJCNo();
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
        public CompanyVM GetCompany(int id = 1)
        {
            _BLCompany = new CompanyBL();
            return _BLCompany.Get(id);
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
