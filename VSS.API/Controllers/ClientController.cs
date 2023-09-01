using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VSS.API.DA.EF.VssDb;
using VSS.BL.Operation;
using VSS.DA.EF.VssDb;
using VSS.DA.ViewModels.Operation;

namespace VSS.API.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    //[VssCorsAttribute]
    public class ClientController : ApiController
    {
        // GET: api/Client
        public IEnumerable<ClientVM> Get()
        {
            ClientBL _BL = new ClientBL();
            return _BL.Get();
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
        public bool Put([FromBody]BusinessPartner model)
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
    }
}
