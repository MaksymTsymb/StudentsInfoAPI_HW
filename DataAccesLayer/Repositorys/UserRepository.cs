﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Setups;

namespace DataAccessLayer.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private static IList<UserWithRoles> usersWithRoles;

        private readonly EFCoreContext dbContext;

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

            return usersWithRoles.FirstOrDefault(x => x.UserId == userId)?.Roles ?? new List<string>();
        }

        public UserDTO GetUserByAuthData(AuthenticationModel authenticationModel)
        {
            return dbContext.Users
                .FirstOrDefault(x =>
                x.Login == authenticationModel.Login &&
                x.Password == authenticationModel.Password);
        }

        public bool RegisterUser(UserDTO userToRegister)
        {
            dbContext.Users.Add(userToRegister);
            dbContext.SaveChanges();

            AddUserWithEmptyRoles(userToRegister.Id);

            return true;
        }

        private IList<UserWithRoles> GetAllUserRoles()
        {
            var items = (from user in dbContext.Set<UserDTO>()
                         join userRole in dbContext.Set<UserRoles>()
                            on user.Id equals userRole.UserId
                         join role in dbContext.Set<Role>()
                            on userRole.RoleId equals role.RoleId
                         select new
                         {
                             role.RoleName,
                             UserId = user.Id
                         }).ToList();

            return items.GroupBy(x => x.UserId)
                .Select(x => new UserWithRoles
                {
                    UserId = x.Key,
                    Roles = x.ToList().Select(x => x.RoleName)
                }).ToList();
        }

        private static void AddUserWithEmptyRoles(Guid userId)
        {
            usersWithRoles.Add(new UserWithRoles
            {
                Roles = new List<string>(),
                UserId = userId
            });
        }
    }
}
