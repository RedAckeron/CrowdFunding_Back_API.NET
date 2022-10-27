using BLL.Interface;
using BLL.Mappers;
using BLL.Models;
using DAL.Interface;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Mapper;
using DALM = DAL.Models;

namespace BLL.Services
{
    public class ProjectService : ObjectMapper, IProjectService
    {
        private readonly IProjectRepo _projectRepo;
        private readonly IStepRepo _stepRepo;

        public ProjectService(IProjectRepo projectRepo, IStepRepo stepRepo)
        {
            _projectRepo = projectRepo;
            _stepRepo = stepRepo;
        }

        public void AddStep(Step step)
        {
            _stepRepo.Create(step.IdProject, step.Amount, step.Reward);
        }
        public void CreateProject(Project p)
        {
            _projectRepo.CreateProject(MapModel<DALM.Project,Project>(p));
        }
        public int ValidateProject(int id)
        {
            return _projectRepo.ValidateProject(id);

        }
        public void Delete(int id)
        {
            _projectRepo.Delete(id);
        }
        public IEnumerable<Project> GetAll()
        {
            return _projectRepo.GetAll().Select(elem => MapModel<Project, DALM.Project>(elem));
        }
        public IEnumerable<Project> GetAllNotValidated()
        {
            return _projectRepo.GetAllNotValidated().Select(elem => MapModel<Project, DALM.Project>(elem));
        }
        public Project GetById(int id)
        {
            Project project = MapModel<Project, DALM.Project>(_projectRepo.GetById(id));
            project.Steps = _stepRepo.GetStepByProject(project.Id)
                .Select(step => MapModel<Step, DALM.Step>(step));

            return project;
        }
        public void Update(Project p)
        {
            _projectRepo.Update(MapModel<DALM.Project, Project>(p));
        }

    }
}