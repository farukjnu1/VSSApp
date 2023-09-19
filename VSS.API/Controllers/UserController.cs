using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using VSS.API.Attributes;
using VSS.API.BL.System;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;
using VSS.API.DA.ViewModels.System;
using VSS.BL.Operation;

namespace VSS.API.Controllers
{
    /// <summary>
    [MyAuth]
    /// </summary>
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<UserVM> Get()
        {
            UserBL _BL = new UserBL();
            return _BL.Get();
        }

        // GET: api/User/5
        public string Get(int id)
            {
                return "value";
            }
        
        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
