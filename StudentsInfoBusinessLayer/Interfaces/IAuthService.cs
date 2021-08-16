using DataAccessLayer.Models;
using BusinessLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IAuthService
    {
        ValidationResult Login(AuthenticationModel authenticationModel);
        bool RegisterUser(User userToRegister);
        bool ConfirmEmail(string message);
    }
}
