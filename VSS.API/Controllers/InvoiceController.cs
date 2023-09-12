using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.BL.Billing;
using VSS.API.BL.Operation;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Billing;
using VSS.API.DA.ViewModels.Operation;

namespace VSS.API.Controllers
{
    public class InvoiceController : ApiController
    {
        // GET: api/Invoice
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Invoice/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Invoice
        public bool Post([FromBody] InvoiceVM model)
        {
            InvoiceBL _BL = new InvoiceBL();
            return _BL.Add(model);
        }

        // PUT: api/Invoice/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Invoice/5
        public void Delete(int id)
        {
        }
    }
}
