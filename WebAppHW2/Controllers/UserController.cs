using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interfaces;
using DataAccessLayer.Models;

namespace WebAppHW2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly ISessionService sessionService;

        public UsersController(IAuthService authService, ISessionService sessionService)
        {
            this.authService = authService;
            this.sessionService = sessionService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public string Login(AuthenticationModel authenticationModel)
        {
            var validationResult = authService.Login(authenticationModel);

            if (!validationResult.IsSuccessful)
            {
                BadRequest("Uncorrect login or password");
                return string.Empty;
            }

            var token = sessionService.CreateAuthenthicationToken(validationResult.UserWithRoles);

            return token;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(User userToRegister)
        {
            var registered = authService.RegisterUser(userToRegister);

            if (registered)
            {
                return Ok(Login(new AuthenticationModel
                {
                    Login = userToRegister.Login,
                    Password = userToRegister.Password
                }));
            }

            return BadRequest("Invalid registration data");
                                                                        }
    }
}