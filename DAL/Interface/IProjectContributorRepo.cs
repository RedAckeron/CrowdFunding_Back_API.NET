using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IProjectContributorRepo
    {
        public void AddContribution(ProjectContributor pc);
        int GetSumOnProjectByUser(int idProject, int idUser);
    }
}
