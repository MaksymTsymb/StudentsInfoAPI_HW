using System;
using System.Collections.Generic;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<string> GetUserRolesById(Guid id);
        User GetUserByAuthData(AuthenticationModel authenticationModel);
        bool RegisterUser(User userToRegister);
    }
}
