using System;
using System.Collections.Generic;
using DataAccessLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        IEnumerable<string> GetUserRolesById(Guid userId);
        UserDTO GetUserByLoginAndPassword(AuthenticationModel authenticationModel);
        bool RegisterUser(UserDTO userToRegister);
        void AddUserMail(Guid userId, string mail);
        bool ConfirmEmail(string message);
    }
}
