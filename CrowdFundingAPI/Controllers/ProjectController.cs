using BLL.Interface;
using BLL.Models;
using CrowdFundingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFundingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_projectService.GetAll());
        }

        [HttpGet("GetAllNotValidated")]
        public IActionResult GetAllNotValidated()
        {
            return Ok(_projectService.GetAllNotValidated());
        }

        [HttpGet("GetOne/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_projectService.GetById(id));
            }

            catch (Exception e)
            {
                return BadRequest("Exception non gérée : " + e.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateProject(ProjectForm p)
        {
            if (!ModelState.IsValid) return BadRequest();
            _projectService.CreateProject(new Project
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
            });
            return Ok();
        }


        [HttpPut("ValidateProject")]
        public IActionResult ValidateProject(int id)
        {
            return Ok(_projectService.ValidateProject(id));
        }

        [Authorize("Admin")]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Project m)
        {
            _projectService.Update(m);
            return Ok();
        }

        [HttpPost("addstep")]
        public IActionResult AddStep(Step step)
        {
            _projectService.AddStep(step);
            return Ok();
        }
    }
}
