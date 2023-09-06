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

        public bool AddJob(Job model)
        {
            try
            {
                model.JobId = GetNewId();
                _vssDb.Jobs.Add(model);
                _vssDb.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateJob(Job model)
        {
            try
            {
                var selectedJob = _vssDb.Jobs
                 .Where(x =>x.JobId == model.JobId).FirstOrDefault();
                if (selectedJob != null)
                {
                    selectedJob.Description = model.Description;
                    selectedJob.JobGroupId = model.JobGroupId;
                    selectedJob.A = model.A;
                    selectedJob.B = model.B;
                    selectedJob.C = model.C;
                    selectedJob.DurationA = model.DurationA;
                    selectedJob.DurationB = model.DurationB;
                    selectedJob.DurationC = model.DurationC;
                    _vssDb.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool RemoveJob(int id)
        {
            try
            {
                var selectedJob = _vssDb.Jobs
                 .Where(x => x.JobId == id)
                 .FirstOrDefault();
                if (selectedJob != null)
                {
                    _vssDb.Jobs.Remove(selectedJob);
                    _vssDb.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        private int GetNewId()
        {
            try
            {
                var jobId = Convert.ToInt32(_vssDb.Jobs.Max(x => x.JobId)) + 1;
                return jobId;
            }
            catch
            {
                return 0;
            }
        }
    }
}
