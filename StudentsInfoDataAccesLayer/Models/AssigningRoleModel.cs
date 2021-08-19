using System;

namespace DataAccessLayer.Models
{
    public class AssigningRoleModel
    {
        public Guid UserId { get; set; }
        public string RoleTitle { get; set; }
    }
}