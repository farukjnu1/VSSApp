using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.Attributes;
using VSS.API.BL.Billing;
using VSS.API.DA.ViewModels.Billing;

namespace VSS.API.Controllers
{
    //[MyAuth]
    public class PayController : ApiController
    {
        // GET: api/Pay
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pay/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pay
        public bool Post([FromBody] PayTranVM model)
        {
            PayBL _BL = new PayBL();
            return _BL.Pay(model);
        }

        // PUT: api/Pay/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pay/5
        public void Delete(int id)
        {
        }
    }
}
