using DataAccessLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface ISessionService
    {
        string CreateAuthenthicationToken(UserWithRoles user);
    }
}