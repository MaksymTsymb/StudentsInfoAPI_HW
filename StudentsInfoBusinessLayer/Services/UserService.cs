using System;
using System.Collections.Generic;
using DataAccesLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<string> GetUserRolesById(Guid id)
        {
            return userRepository.GetUserRolesById(id);
        }
    }
}
