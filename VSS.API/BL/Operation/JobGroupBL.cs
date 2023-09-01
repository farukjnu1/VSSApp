using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSS.API.DA.EF.VssDb;
using VSS.DA.EF.VssDb;

namespace VSS.BL.Operation
{
    public class JobGroupBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        List<JobGroup> listJobGroup = null;

        public IEnumerable<JobGroup> Get()
        {
            return listJobGroup = _vssDb.JobGroups.ToList();
        }
    }
}
