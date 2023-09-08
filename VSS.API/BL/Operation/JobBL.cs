using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSS.API.DA.EF.VssDb;
using VSS.API.DA.ViewModels.Operation;

namespace VSS.BL.Operation
{
    public class JobBL
    {
        ModelVssDb _vssDb = new ModelVssDb();
        List<Job> listJob = null;

        public IEnumerable<JobVM> Get(int pageIndex = 0, int pageSize = 5)
        {
            int nRow = _vssDb.Jobs.Count();
            var listJob = _vssDb.Jobs
                .Select(x => new JobVM
                {
                    JobId = x.JobId,
                    Description = x.Description,
                    JobGroupId = x.JobGroupId,
                    A = x.A,
                    B = x.B,
                    C = x.C,
                    DurationA = x.DurationA,
                    DurationB = x.DurationB,
                    DurationC = x.DurationC,

                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    RowCount = nRow
                })
                .OrderByDescending(s => s.JobId)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
            return listJob;
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
