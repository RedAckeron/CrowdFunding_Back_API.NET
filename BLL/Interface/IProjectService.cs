using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IProjectService
    {
        public void CreateProject(Project p);
        public void Update(Project p);
        public Project GetById(int id);
        public IEnumerable<Project> GetAll();
        public IEnumerable<Project> GetAllNotValidated();
        public int ValidateProject(int id);
        public void Delete(int id);
        public void AddStep(Step step);
    }
}
