using Microsoft.EntityFrameworkCore;
using System;
    
namespace DataAccesLayer.Models
{
    [Keyless]
    public class UserRoles
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
