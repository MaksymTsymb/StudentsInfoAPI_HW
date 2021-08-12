using System;
using System.Collections.Generic;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<string> GetUserRolesById(Guid userId);
        UserDTO GetUserByAuthData(AuthenticationModel authenticationModel);
        bool RegisterUser(UserDTO userToRegister);
    }
}
