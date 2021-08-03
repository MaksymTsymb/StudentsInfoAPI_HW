using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private class UserWithRoles
        {
            public Guid UserId { get; set; }
            public IEnumerable<string> Roles { get; set; }
        }

        private readonly EFCoreContext dbContext;
        private IEnumerable<UserWithRoles> usersWithRoles;

        public UserRepository(EFCoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<string> GetUserRolesById(Guid userId)
        {
            if (usersWithRoles == null)
            {
                usersWithRoles = GetAllUserRoles();
            }

            return usersWithRoles.FirstOrDefault(x => x.UserId == userId)?.Roles;
        }

        private IEnumerable<UserWithRoles> GetAllUserRoles()
        {
            var items = (from user in dbContext.Set<User>()
                         join userRole in dbContext.Set<UserRoles>()
                            on user.Id equals userRole.UserId
                         join role in dbContext.Set<Role>()
                            on userRole.RoleId equals role.Id
                         select new Models.UserWithRoles
                         {
                             Role = role.RoleName,
                             UserId = user.Id
                         }).ToList();

            return items.GroupBy(x => x.UserId)
                .Select(x => new UserWithRoles
                {
                    UserId = x.Key,
                    Roles = x.ToList().Select(x => x.Role)
                });
        }
    }
}
