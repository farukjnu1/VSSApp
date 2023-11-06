using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VSS.API.Attributes;
using VSS.API.BL.Stores;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;
using VSS.BL.Operation;
using VSS.DA.ViewModels.Operation;

namespace VSS.API.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    //[VssCorsAttribute]
    [MyAuth]
    public class ClientController : ApiController
    {
        // GET: api/Client
        public IEnumerable<ClientVM> Get([FromUri] string phone, int pi = 0, int ps = 10)
        {
            ClientBL _BL = new ClientBL();
            return _BL.Get(phone, pi, ps);
        }

        // GET: api/Client/5
        public ClientVM Get(int id)
        {
            ClientBL _BL = new ClientBL();
            return _BL.Get(id);
        }

        // POST: api/Client
        public bool Post([FromBody] BusinessPartner model)
        {
            ClientBL _BL = new ClientBL();
            return _BL.Add(model);
        }

        // PUT: api/Client/5
        public bool Put([FromBody] BusinessPartner model)
        {
            ClientBL _BL = new ClientBL();
            return _BL.Update(model);
        }

        // DELETE: api/Client/5
        public bool Delete(int id)
        {
            ClientBL _BL = new ClientBL();
            return _BL.Remove(id);
        }


        [HttpGet]
        [Route("api/Client/getSuplierName")]
        public IEnumerable<ClientVM> getSuplierName()
        {
            ClientBL _BL = new ClientBL();
            return _BL.getSName();
        }
    }
}
