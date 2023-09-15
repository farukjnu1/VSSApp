using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.Attributes;
using VSS.API.BL.Stores;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Stores;


namespace VSS.API.Controllers
{
    //[MyAuth]
    public class SRController : ApiController
    {
        // GET: api/SR
        public IEnumerable<StoreReq> Get()
        {
           SRBL _BL = new SRBL();
           return _BL.Get();
        }

        // GET: api/SR/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SR
        public bool Post([FromBody] StoreReq model)
        {
            SRBL _BL = new SRBL();
            return _BL.Add(model);
        }

        // PUT: api/SR/5
        public bool Put([FromBody] StoreReq model)
        {
            SRBL _BL = new SRBL();
            return (_BL.Update(model));
        }

        // DELETE: api/SR/5
        public bool Delete(int id)
        {
            SRBL _BL = new SRBL();
            return _BL.Remove(id);
        }


        
    }
}
