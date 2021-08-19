using System.Linq;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Setups;

namespace DataAccessLayer.Repositories
{
    public class UserRolesRepository : IUserRolesRepository
    {
        private readonly EFCoreContext dbContext;

        public UserRolesRepository(EFCoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool AddUserRole(AssigningRoleModel assigningRoleModel)
        {
            var userId = assigningRoleModel.UserId;
            var role = dbContext.Roles.First(x => x.RoleName == assigningRoleModel.RoleTitle);
            var roleId = role.RoleId;
            var newRole = new UserRoles
            {
                UserId = userId,
                RoleId = roleId
            };

            dbContext.UserRoles.Add(newRole);

            return dbContext.SaveChanges() != 0;
        }
    }
}