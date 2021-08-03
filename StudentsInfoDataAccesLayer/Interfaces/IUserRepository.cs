using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<string> GetUserRolesById(Guid id);
    }
}
