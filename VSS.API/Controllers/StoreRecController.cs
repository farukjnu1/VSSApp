using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VSS.API.Controllers
{
    public class StoreRecController : ApiController
    {
        // GET: api/StoreRec
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/StoreRec/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/StoreRec
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/StoreRec/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/StoreRec/5
        public void Delete(int id)
        {
        }
    }
}
