using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IStepUserRepo
    {
        public IEnumerable<Step> GetStepsUserByProjectAndUser(int projectId, int userId);
        public bool AddStepUser(int projectId, int userId, int stepId);
    }
}
