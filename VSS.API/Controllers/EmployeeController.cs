using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.Attributes;
using VSS.API.BL.HR;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.HR;

namespace VSS.API.Controllers
{
    [MyAuth]
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        public IEnumerable<EmployeeVM> Get([FromUri] string phone, int pi = 0, int ps = 10)
        {
            EmployeeBL _BL = new EmployeeBL();
            return _BL.Get(phone, pi, ps);
        }

        // GET: api/Employee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        public bool Post([FromBody] Employee model)
        {
            EmployeeBL _BL = new EmployeeBL();
            return _BL.Add(model);
        }

        // PUT: api/Employee/5
        public bool Put([FromBody] Employee model)
        {
            EmployeeBL _BL = new EmployeeBL();
            return _BL.Update(model);
        }

        // DELETE: api/Employee/5
        public bool Delete(int id)
        {
            EmployeeBL _BL = new EmployeeBL();

            return _BL.Remove(id);
        }
    }
}
