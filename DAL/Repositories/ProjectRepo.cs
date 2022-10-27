

using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using ToolBox;
using ToolBox.Models;

namespace DAL.Repositories
{
	public class ProjectRepo : Connection, IProjectRepo 
	{
		private string _connectionString;
        public ProjectRepo(IConfiguration config) : base(config) { }
        public void Delete(int id)
        {
            Command cmd = new Command("DELETE FROM Project WHERE Id = @id");
            cmd.AddParameter("id", id);
            ExecuteNonQuery(cmd);
        }
        public IEnumerable<Project> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Project");
            return ExecuteReader<Project>(cmd);
        }
        public IEnumerable<Project> GetAllNotValidated()
        {
            Command cmd = new Command("SELECT * FROM Project where isValidate = 0");
            return ExecuteReader<Project>(cmd);
        }
        public Project GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM Project WHERE Id = @id");
            cmd.AddParameter("id", id);
            return ExecuteReader<Project>(cmd).First();


        }
        public void Update(Project p)
        {
            Command cmd = new Command("UPDATE Project SET IdOwner = @IdOwner, Title = @title, Description = @Description, Goal = @Goal, BeginDate = CONVERT(date,@BeginDate), EndDate = CONVERT(date,@EndDate), IsValidate = @IsValidate " +
                        " WHERE Id = @id");
            cmd.AddParameter("IdOwner", p.IdOwner);
            cmd.AddParameter("Title", p.Title);
            cmd.AddParameter("Description", p.Description);
            cmd.AddParameter("Goal", p.Goal);
            cmd.AddParameter("BeginDate", p.BeginDate);
            cmd.AddParameter("EndDate", p.EndDate);
            cmd.AddParameter("IsValidate", p.IsValidate);
            cmd.AddParameter("id", p.Id);

            ExecuteNonQuery(cmd);
                
        }
        public int ValidateProject(int id)
        {
            Command cmd = new Command("UPDATE Project SET IsValidate = 1 WHERE Id = @id");
            cmd.AddParameter("id", id);
            return ExecuteNonQuery(cmd);
        }
        public void CreateProject(Project p)
		{
            Command cmd = new Command("INSERT INTO Project (IdOwner, Title, Description, Goal, BeginDate, EndDate, IsValidate) " +
                        "VALUES (@IdOwner, @Title, @Description, @Goal, CONVERT(date,@BeginDate), CONVERT(date,@EndDate), @IsValidate)");
                    cmd.AddParameter("IdOwner", p.IdOwner);
                    cmd.AddParameter("Title", p.Title);
                    cmd.AddParameter("Description", p.Description);
                    cmd.AddParameter("Goal", p.Goal);
                    cmd.AddParameter("BeginDate", p.BeginDate);
                    cmd.AddParameter("EndDate", p.EndDate);
                    cmd.AddParameter("IsValidate", p.IsValidate);

            ExecuteNonQuery(cmd);
        }
    }
}