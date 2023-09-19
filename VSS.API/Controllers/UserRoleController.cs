using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.Attributes;
using VSS.API.BL.System;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;
using VSS.API.DA.ViewModels.System;
using VSS.BL.Operation;

namespace VSS.API.Controllers
{
    [MyAuth]
    public class UserRoleController : ApiController
    {
        // GET: api/UserRole
        /*public IEnumerable<UserRoleVM> Get()
        {
            UserRoleBL _BL = new UserRoleBL();
            return _BL.Get();
        }*/

        // GET: api/UserRole/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserRole
        public bool Post([FromBody] List<UserRoleVM> listModel)
        {
            UserRoleBL _BL = new UserRoleBL();
            return _BL.add(listModel);
        }

        // PUT: api/UserRole/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserRole/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("api/UserRole/GetUserRole")]
        public List<UserRoleVM> GetUserRole(int userId)
        {
            return new UserRoleBL().GetUserRole(userId);
        }
    }
}
