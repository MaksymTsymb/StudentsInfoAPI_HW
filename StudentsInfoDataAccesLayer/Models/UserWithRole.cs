using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.Models
{
    public class UserWithRole
    {
        public Guid UserId { get; set; }
        public string Role { get; set; }
    }
}
