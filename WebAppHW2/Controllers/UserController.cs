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
        private readonly IAuthenticationService authService;
        private readonly ISessionService sessionService;
        private readonly IUserService userService;

        public UsersController(IAuthenticationService authService, ISessionService sessionService, IUserService userService)
        {
            this.authService = authService;
            this.sessionService = sessionService;
            this.userService = userService;
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

        [AllowAnonymous]
        [HttpGet("confirm")]
        public IActionResult Confirm(string message)
        {
            var result = authService.ConfirmEmail(message);
            if (result.IsSuccessful)
            {
                userService.AddUserRole(
               new AssigningRoleModel
               {
                   UserId = result.UserId.Value,
                   RoleTitle = "Administrator"
               });
            }

            return Ok(result.IsSuccessful);
        }
    }
}