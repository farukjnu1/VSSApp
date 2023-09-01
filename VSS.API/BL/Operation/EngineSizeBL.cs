using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSS.API.DA.EF.VssDb;
using VSS.DA.EF.VssDb;

namespace VSS.BL.Operation
{
    public class EngineSizeBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        List<EngineSize> listEngineSize = null;

        public IEnumerable<EngineSize> Get()
        {
            return listEngineSize = _vssDb.EngineSizes.ToList();
        }
    }
}
