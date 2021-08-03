using BusinessLayer.Interfaces;
using DataAccessLayer.Models;

namespace BusinessLayer.JWTFolder.Services
{
    public class AuthService
    {
        private readonly IUserService userService;
        private readonly IHashService hashService;

        public AuthService(IUserService userService, IHashService hashService)
        {
            this.userService = userService;
            this.hashService = hashService;
        }

        public ValidationResult Login(AuthenticationModel authenticationModel)
        {
            var hashedPassword = hashService.HashString(authenticationModel.Password);
            authenticationModel.Password = hashedPassword;

            var user = userService.GetUserByLoginAndPassword(authenticationModel);

            if (user != null)
            {
                var roles = userService.GetUserRolesById(user.Id);
                return new ValidationResult(true,
                    new UserWithRoles
                    {
                        UserId = user.Id,
                        Roles = roles
                    });
            }

            return new ValidationResult(false, null);
        }

        public bool Register(User userToRegister)
        {
            var originalPassword = userToRegister.Password;
            userToRegister.Password = hashService.HashString(userToRegister.Password);

            var response = userService.RegisterUser(userToRegister);

            userToRegister.Password = originalPassword;

            return response;
        }
    }
}