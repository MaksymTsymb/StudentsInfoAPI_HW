using DataAccessLayer.Models;

namespace BusinessLayer.Models
{
    public class ValidationResult
    {
        public bool IsSuccessful { get; set; }
        public UserWithRoles UserWithRoles { get; set; }

        public ValidationResult(bool isSuccessful, UserWithRoles userWithRole)
        {
            IsSuccessful = isSuccessful;
            UserWithRoles = userWithRole;
        }
    }
}