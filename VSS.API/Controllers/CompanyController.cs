﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.Attributes;
using VSS.API.BL.System;
using VSS.API.DA.ViewModels.Operation;
using VSS.API.DA.ViewModels.System;

namespace VSS.API.Controllers
{
    [MyAuth]
    public class CompanyController : ApiController
    {
        // GET: api/Company
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Company/5
        public void Delete(int id)
        {
        }
    }
}