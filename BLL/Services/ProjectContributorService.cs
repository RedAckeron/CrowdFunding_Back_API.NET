using BLL.Interface;
using BLL.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Mapper;
using DALM = DAL.Models;

namespace BLL.Services
{
    public class ProjectContributorService : ObjectMapper, IProjectContributorService
    {
        private readonly IProjectContributorRepo _projectContributorRepo;
        private readonly IProjectService _projectService;
        private readonly IStepUserRepo _stepUserRepo;

        public ProjectContributorService(IProjectContributorRepo projectContributorRepo, IProjectService projectService, IStepUserRepo stepUserRepo)
        {
            _projectContributorRepo = projectContributorRepo;
            _projectService = projectService;
            _stepUserRepo = stepUserRepo;
        }

        public void AddContribution(ProjectContributor pc)
        {
            _projectContributorRepo.AddContribution(MapModel<DALM.ProjectContributor, ProjectContributor>(pc));

            int totalContrib = _projectContributorRepo.GetSumOnProjectByUser(pc.IdProject, pc.IdUser);

            Project project = _projectService.GetById(pc.IdProject);

            IEnumerable<Step> stepsUsers = _stepUserRepo.GetStepsUserByProjectAndUser(pc.IdProject, pc.IdUser)
                .Select(step => MapModel<Step, DALM.Step>(step));
            
            foreach(Step stepProj in project.Steps)
            {
                Console.WriteLine(totalContrib);
                if (totalContrib >= stepProj.Amount)
                {
                    Console.WriteLine("Deuxieme if");
                    if (!stepsUsers.Any(step => step.Id == stepProj.Id))
                    {
                        Console.WriteLine("Dernier if");
                        _stepUserRepo.AddStepUser(pc.IdProject, pc.IdUser, stepProj.Id);
                    }
                }
            }  
        }
    }
}
