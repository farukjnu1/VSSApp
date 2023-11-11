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
using VSS.BL.Operation;
using VSS.DA.ViewModels.Operation;

namespace VSS.API.Controllers
{
    [MyAuth]
    public class BrandController : ApiController
    {
        // GET: api/Brand
        public IEnumerable<BrandVM> Get([FromUri] string phone, int pi = 0, int ps = 10)
        {
            BrandBL _BL = new BrandBL();
            return _BL.Get(phone, pi, ps);
        }

        // GET: api/Brand/5
        //Test for push to github
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Brand
        public bool Post([FromBody] Brand model)
        {
            BrandBL _BL = new BrandBL();
            return _BL.Add(model);
        }

        // PUT: api/Brand/5
        public bool Put([FromBody] Brand model)
        {
            BrandBL _BL = new BrandBL();
            return _BL.Update(model);
        }

        // DELETE: api/Brand/5
        public bool Delete(int id)
        {
            BrandBL _BL = new BrandBL();
            return _BL.Remove(id);
        }
    }
}
