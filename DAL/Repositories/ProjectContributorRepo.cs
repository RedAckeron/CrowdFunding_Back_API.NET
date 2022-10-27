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
    public class ProjectContributorRepo : Connection, IProjectContributorRepo
    {
        public ProjectContributorRepo(IConfiguration config) : base(config) { }
        public void AddContribution(ProjectContributor pc)
        {
            Command cmd = new Command("INSERT INTO Project_Contributor (IdProject, IdUser, Amount, InsertDate) " +
                        "VALUES (@IdProject, @IdUser, @Amount, CONVERT(date,GETDATE()))");
            cmd.AddParameter("IdProject", pc.IdProject);
            cmd.AddParameter("IdUser", pc.IdUser);
            cmd.AddParameter("Amount", pc.Amount);

            ExecuteNonQuery(cmd); 
        }

        public int GetSumOnProjectByUser(int idProject, int idUser)
        {
            Command cmd = new Command("GetSumOnProjectByUser", true);

            cmd.AddParameter("idProject", idProject);
            cmd.AddParameter("idUser", idUser);

            return ExecuteScalar(cmd);
        }
    }
}
