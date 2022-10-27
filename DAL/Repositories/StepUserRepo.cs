using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;
using ToolBox.Models;

namespace DAL.Repositories
{
    public class StepUserRepo : Connection, IStepUserRepo
    {
        public StepUserRepo(IConfiguration config) : base(config){}

        public IEnumerable<Step> GetStepsUserByProjectAndUser(int projectId, int userId)
        {
            Command cmd = new Command("GetStepsUserByProjectAndUser", true);

            cmd.AddParameter("userId", userId);
            cmd.AddParameter("projectId", projectId);

            return ExecuteReader<Step>(cmd);
        }

        public bool AddStepUser(int projectId, int userId, int stepId)
        {
            Command cmd = new Command("INSERT INTO Step_User (IdUser, IdProject, IdStep) VALUES(@projectId, @userId, @stepId)");

            cmd.AddParameter("@projectId", projectId);
            cmd.AddParameter("@userId", userId);
            cmd.AddParameter("@stepId", stepId);

            return ExecuteNonQuery(cmd) == 1; 
        }
    }
}
