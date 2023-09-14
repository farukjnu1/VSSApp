using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.BL.System;
using VSS.API.DA.ViewModels.System;

namespace VSS.API.Controllers
{
    public class MenuPermissionController : ApiController
    {
        // GET: api/MenuPermission
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MenuPermission/5
        [HttpGet]
        [Route("api/MenuPermission/GetMenuPermission")]
        public List<MenuPermissionVM> GetMenuPermission(int RoleId)
        {
            return new MenuPermissionBL().GetMenuPermission(RoleId);
        }

        // POST: api/MenuPermission
        public bool Post([FromBody] List<MenuPermissionVM> Model)
        {
            MenuPermissionBL _BL = new MenuPermissionBL();
            return _BL.add(Model);
        }

        // PUT: api/MenuPermission/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MenuPermission/5
        public void Delete(int id)
        {
        }
    }
}
