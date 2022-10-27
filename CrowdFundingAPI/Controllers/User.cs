using BLL.Interface;
using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.User;
using DemoAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLLM = BLL.Models;

namespace CrowdFundingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        private readonly TokenManager _tokenManager;
        private readonly ILocalUserService _LocalUserService;
        public User(ILocalUserService service, TokenManager tokenManager)
        {
            _LocalUserService = service;
            _tokenManager = tokenManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_LocalUserService.GetAll());
        }

        [HttpPost("login")]
        public IActionResult Login(LoginForm form)
        {
            BLLM.User u = _LocalUserService.Login(form.email, form.password);
            ConnectedUser cu = new ConnectedUser
            {
                Id = u.Id,
                NickName = u.NickName,
                Token = _tokenManager.GenerateToken(u)
            };

            return Ok(cu);
        }

        [HttpPost("register")]
        public IActionResult RegisterUser(UserForm user)
        {
            return Ok(_LocalUserService.RegisterUser(user.NickName, user.Email, user.Password, user.BirthDate, user.IdRole));
        }

        [HttpPut("update")]
        public IActionResult UpdateUser(UserForm user)
        {
            Console.WriteLine("yo");
            return Ok(_LocalUserService.UpdateUser(user.Id, user.NickName, user.Email, user.BirthDate));
        }

        [HttpGet("{idUser}")]
        public IActionResult GetOne(int idUser)
        {
            return Ok(_LocalUserService.GetOne(idUser));
        }

        [HttpPost("UserSwapStatus")]
        public IActionResult UserSwapStatus(int id)
        {
            return Ok(_LocalUserService.UserSwapStatus(id));
        }
    }
}