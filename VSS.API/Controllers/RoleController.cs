using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.Attributes;
using VSS.API.BL.System;
using VSS.API.DA.ViewModels.System;

namespace VSS.API.Controllers
{
    //[MyAuth]
    public class RoleController : ApiController
    {
        // GET: api/Role
        public IEnumerable<RoleVM> Get()
        {
            RoleBL _BL = new RoleBL();
            return _BL.get();
        }

        // GET: api/Role/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Role
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Role/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Role/5
        public void Delete(int id)
        {
        }
    }
}
