using System;
using System.Collections.Generic;
using BusinessLayer.Models;
using DataAccessLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        IEnumerable<string> GetUserRolesById(Guid userId);
        UserDTO GetUserByLoginAndPassword(AuthenticationModel authenticationModel);
        bool RegisterUser(UserDTO userToRegister);
        void AddUserMail(Guid userId, string mail);
        ConfirmationResult ConfirmEmail(string message);
        bool AddUserRole(AssigningRoleModel addUserRoleModel);
    }
}
