using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public string Password { get; set; }
    }
}
