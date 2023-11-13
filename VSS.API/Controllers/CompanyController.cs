﻿using System;
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
using VSS.DA.ViewModels.Operation;

namespace VSS.API.Controllers
{
    [MyAuth]
    public class CompanyController : ApiController
    {
        // GET: api/Company
        [HttpGet]
        [Route("api/Company/GetCompany")]
        public IEnumerable<CompanyVM> GetCompany()
        {
            CompanyBL _BL = new CompanyBL();
            return _BL.GetCompany();
        }

        // GET: api/Company/5
        public CompanyVM Get(int id)
        {
            return new CompanyBL().Get(id);
        }

        // POST: api/Company
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Company/5
        public bool Put([FromBody] Company model)
        {
            CompanyBL _BL = new CompanyBL();
            return _BL.Update(model);
        }

        // DELETE: api/Company/5
        public void Delete(int id)
        {
        }
    }
}
