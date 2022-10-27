using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLLM = BLL.Models;
using DALM = DAL.Models;

namespace BLL.Mappers
{
    public static class ProjectMappers
    {
        public static BLLM.Project ToBll(this DALM.Project p)
        {
            return new BLLM.Project
            {
                Id = p.Id,
                IdOwner = p.IdOwner,
                Title = p.Title,
                Description = p.Description,
                Goal = p.Goal,
                BeginDate = p.BeginDate,
                EndDate = p.EndDate,
                //IdUser = p.IdUser,
                IsValidate = p.IsValidate
            };
        }

        public static DALM.Project ToDal(this BLLM.Project p)
        {
            return new DALM.Project
            {
                Id = p.Id,
                IdOwner = p.IdOwner,
                Title = p.Title,
                Description = p.Description,
                Goal = p.Goal,
                BeginDate = p.BeginDate,
                EndDate = p.EndDate,
                //IdUser = p.IdUser,
                IsValidate = p.IsValidate
            };
        }
    }
}
