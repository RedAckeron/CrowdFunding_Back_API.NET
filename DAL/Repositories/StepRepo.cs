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
    public class StepRepo : Connection, IStepRepo
    {
        public StepRepo(IConfiguration config) : base(config)
        {
        }

        public bool Create(int idProject, int amount, string reward)
        {
            Command cmd = new Command("CreateStep", true);

            cmd.AddParameter("idProject", idProject);
            cmd.AddParameter("amout", amount);
            cmd.AddParameter("reward", reward);

            return ExecuteNonQuery(cmd) == 1;
        }

        public bool Delete(int id)
        {
            Command cmd = new Command("Delete", true);

            cmd.AddParameter("id", id);

            return ExecuteNonQuery(cmd) == 1;
        }

        public Step Get(int id)
        {
            Command cmd = new Command("GetOne", true);

            cmd.AddParameter("id", id);

            return ExecuteReader<Step>(cmd).First();
        }

        public IEnumerable<Step> GetAll()
        {
            Command cmd = new Command("GetAll", true);

            return ExecuteReader<Step>(cmd);
        }

        public bool Update(int id, int idProject, int amount, string reward)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Step> GetStepByProject(int idProject)
        {
            Command cmd = new Command("GetStepsByProject", true);
            cmd.AddParameter("idProject", idProject);

            return ExecuteReader<Step>(cmd);
        }
    }
}
