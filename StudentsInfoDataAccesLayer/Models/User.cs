using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Password { get; set; }

        //[Required]
        public string Email { get; set; }

    }
}
