using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IStepRepo
    {
        public IEnumerable<Step> GetAll();
        public Step Get(int id);
        public bool Create(int idProject, int amount, string reward);
        public bool Update(int id, int idProject, int amount, string reward);
        public bool Delete(int id);
        public IEnumerable<Step> GetStepByProject(int idProject);
    }
}
