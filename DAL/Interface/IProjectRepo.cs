using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IProjectRepo
    {
        public void CreateProject(Project p);
        public void Update(Project p);
        public Project GetById(int id);
        public IEnumerable<Project> GetAll(); 
        public IEnumerable<Project> GetAllNotValidated();
        public void Delete(int id);
        public int ValidateProject(int id);
    }
}