using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Setups;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class MailRepository : IMailRepository
    {
        private readonly EFCoreContext dbContext;
        public MailRepository(EFCoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool ConfirmMail(EmailDTO email)
        {
            var entity = dbContext.Emails.Where(x =>
                x.UserId == email.UserId &&
                x.ConfirmationMessage == email.ConfirmationMessage).FirstOrDefault();

            if (entity != null)
            {
                entity.IsConfirmed = true;
                dbContext.SaveChanges();
            }
            ///////////////////////////////asign a role here
            return entity != null;
        }

        public void SaveMail(EmailDTO email)
        {
            dbContext.Emails.Add(email);
            dbContext.SaveChanges();
        }
    }
}