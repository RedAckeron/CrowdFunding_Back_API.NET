using BLL.Interface;
using BLL.Models;
using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLLM = BLL.Models;

namespace CrowdFundingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectContributorController : Controller
    {
        private readonly IProjectContributorService _projectContributorService;
        public ProjectContributorController(IProjectContributorService projectContributorService)
        {
            _projectContributorService = projectContributorService;
        }


        [HttpPost]
        public IActionResult AddContribution(ProjectContributorForm pc)
        {

            if (!ModelState.IsValid) return BadRequest();
            _projectContributorService.AddContribution(new ProjectContributor
            {
                IdProject = pc.IdProject,
                IdUser = pc.IdUser,
                Amount = pc.Amount
            }); 
            return Ok();
        }
        
    }
}
