using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VSS.API.BL.Stores;
using VSS.API.BL.System;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Stores;
using VSS.API.DA.ViewModels.System;

namespace VSS.API.Controllers
{
    public class BrandModelController : ApiController
    {
        // GET: api/BrandModel
        public IEnumerable<BrandModelVM> Get([FromUri] string phone, int pi = 0, int ps = 10)
        {
            BrandModelBL _BL = new BrandModelBL();
            return _BL.Get(phone, pi, ps);
        }

        // GET: api/BrandModel/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BrandModel
        public bool Post([FromBody] BrandModel model)
        {
            BrandModelBL _BL = new BrandModelBL();
            return _BL.Add(model);
        }

        // PUT: api/BrandModel/5
        public bool Put([FromBody] BrandModel model)
        {
            BrandModelBL _BL = new BrandModelBL();
            return _BL.Update(model);
        }

        // DELETE: api/BrandModel/5
        public bool Delete(int id)
        {
            BrandModelBL _BL = new BrandModelBL();
            return _BL.Remove(id);
        }
    }
}
