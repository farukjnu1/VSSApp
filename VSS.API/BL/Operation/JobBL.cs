using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSS.API.DA.EF.VssDb;
using VSS.DA.EF.VssDb;

namespace VSS.BL.Operation
{
    public class JobBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        List<Job> listJob = null;

        public IEnumerable<Job> Get()
        {
            return listJob = _vssDb.Jobs.ToList();
        }
    }
}
