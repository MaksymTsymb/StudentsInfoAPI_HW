using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace BusinessLayer.Services
{
    public class MailService : IMailService
    {
        private readonly IMailRepository mailRepository;
        private readonly IMapper mapper;

        public MailService(IMailRepository mailRepository, IMapper mapper)
        {
            this.mailRepository = mailRepository;
            this.mapper = mapper;
        }

        public bool ConfirmMail(ConfirmationMessageModel model)
        {
            return mailRepository.ConfirmMail(mapper.Map<EmailDTO>(model));
        }

        public void SaveMailAddress(EmailDTO email)
        {
            mailRepository.SaveMail(email);
        }
    }
}