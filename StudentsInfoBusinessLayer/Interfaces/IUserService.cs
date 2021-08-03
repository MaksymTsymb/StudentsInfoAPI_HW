using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface IUserService
    {
        IEnumerable<string> GetUserRolesById(Guid userId);
    }
}
