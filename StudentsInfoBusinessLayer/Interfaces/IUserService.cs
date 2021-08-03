using System;
using System.Collections.Generic;
using DataAccessLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        IEnumerable<string> GetUserRolesById(Guid userId);
        User GetUserByLoginAndPassword(AuthenticationModel authenticationModel);
        bool RegisterUser(User userToRegister);
    }
}
