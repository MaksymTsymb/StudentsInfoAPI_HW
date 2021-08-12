using System;
using System.Collections.Generic;
using DataAccessLayer.Interfaces;
using BusinessLayer.Interfaces;
using DataAccessLayer.Models;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserDTO GetUserByLoginAndPassword(AuthenticationModel authenticationModel)
        {
            return userRepository.GetUserByAuthData(authenticationModel);
        }

        public IEnumerable<string> GetUserRolesById(Guid id)
        {
            return userRepository.GetUserRolesById(id);
        }

        public bool RegisterUser(UserDTO userToRegister)
        {
            try
            {
                userToRegister.Id = Guid.NewGuid();
                userRepository.RegisterUser(userToRegister);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
