using AutoMapper;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BlogMangementApi.Controllers
{
    [ApiController]
    [Route("/api/Auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        private readonly IMapper _mapper;
        public AuthController(IAuthRepository authRepo, IMapper mapper)
        {

            _authRepo = authRepo;
            _mapper = mapper;

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authRepo.Login(model);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(loginResponse);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            bool ifUserNameUnique = _authRepo.IsUniqueUser(model.UserName);
            if (!ifUserNameUnique)
            {
                return BadRequest(new { message = "Username already exists" });
            }
            var user = await _authRepo.Register(model);
            if (user == null)
            {
                return BadRequest(new { message = "Error while registering" });
            }
            return Ok(model);
        }
    }
}
