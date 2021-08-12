using AutoMapper;
using System.Text.RegularExpressions;
using DataAccessLayer.Models;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;


namespace BusinessLayer.Services
{
    public class AuthenthicationService : IAuthService
    {
        private readonly IUserService userService;
        private readonly IHashService hashService;
        private readonly IMapper mapper;

        public AuthenthicationService(
            IUserService userService,
            IHashService hashService,
            IMapper mapper)
        {
            this.userService = userService;
            this.hashService = hashService;
            this.mapper = mapper;
        }

        public ValidationResult Login(AuthenticationModel authenticationModel)
        {
            var hashedPassword = hashService.HashString(authenticationModel.Password);
            authenticationModel.Password = hashedPassword;

            var user = userService.GetUserByLoginAndPassword(authenticationModel);
            UserWithRoles userWithRoles = null;
            var userNotNull = user != null;

            if (userNotNull)
            {
                var roles = userService.GetUserRolesById(user.Id);
                userWithRoles = new UserWithRoles
                {
                    UserId = user.Id,
                    Roles = roles
                };
            }

            return new ValidationResult(userNotNull, userWithRoles);
        }

        public bool RegisterUser(User userToRegister)
        {
            if (!IsPasswordValid(userToRegister.Password))
            {
                return false;
            }

            var userDTO = mapper.Map<UserDTO>(userToRegister);
            userDTO.Password = hashService.HashString(userToRegister.Password);

            var response = userService.RegisterUser(userDTO);

            return response;
        }

        private bool IsPasswordValid(string password)
        {
            var regEx = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])((?=.*?[0-9])|(?=.*?[#?!@$%^&*-]))", RegexOptions.Compiled);

            return regEx.IsMatch(password);
        }
    }
}