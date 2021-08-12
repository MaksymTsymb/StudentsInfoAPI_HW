using System;

namespace DataAccessLayer.Models
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
    }
}
