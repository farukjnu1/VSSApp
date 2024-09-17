﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.BL.Billing;
using VSS.API.BL.Purchase;
using VSS.API.DA.ViewModels.Billing;
using VSS.API.DA.ViewModels.Operation;
using VSS.API.DA.ViewModels.Purchase;

namespace VSS.API.Controllers
{
    public class PoController : ApiController
    {
        // GET: api/Invoice
        public IEnumerable<PoVm> Get(int pi = 0, int ps = 5, DateTime? startDate = null, DateTime? endDate = null)
        {
            PoBL _BL = new PoBL();
            return _BL.Get(pi, ps, startDate, endDate);
        }

        // GET: api/Invoice/5
        public PoVm Get(long id)
        {
            PoBL _BL = new PoBL();
            return _BL.Get(id);
        }

        // POST: api/Invoice
        public bool Post([FromBody] PoVm model)
        {
            PoBL _BL = new PoBL();
            return _BL.Add(model);
        }

        // PUT: api/Invoice/5
        public bool Put([FromBody] PoVm model)
        {
            PoBL _BL = new PoBL();
            return _BL.Update(model);
        }

        // DELETE: api/Invoice/5
        public bool Delete(long id)
        {
            PoBL _BL = new PoBL();
            return _BL.Remove(id);
        }

    }
}
