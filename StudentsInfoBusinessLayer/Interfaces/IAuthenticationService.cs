using DataAccessLayer.Models;
using BusinessLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IAuthenticationService
    {
        ValidationResult Login(AuthenticationModel authenticationModel);
        bool RegisterUser(User userToRegister);
        ConfirmationResult ConfirmEmail(string message);
    }
}
