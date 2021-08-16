using System;
using System.Collections.Generic;
using System.Text.Json;
using AutoMapper;
using BusinessLayer.Helpers;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMailService mailService;
        private readonly IMailExchangerService mailExchangerService;
        private readonly IMapper mapper;

        public UserService(
            IUserRepository userRepository,
            IMailService mailService,
            IMailExchangerService mailExchangerService,
            IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mailService = mailService;
            this.mailExchangerService = mailExchangerService;
            this.mapper = mapper;
        }

        public void AddUserMail(Guid userId, string mail)
        {
            var confirmationModel = new ConfirmationMessageModel
            {
                ConfirmationMessage = StringGenerator.GenerateString(),
                UserId = userId
            };
            var modelToSerialize = JsonSerializer.Serialize(confirmationModel);
            var messageToSend = EncryptionHelper.Encrypt(modelToSerialize);

            mailService.SaveMailAddress(new EmailDTO
            {
                ConfirmationMessage = confirmationModel.ConfirmationMessage,
                Email = mail,
                IsConfirmed = false,
                UserId = userId
            });

            mailExchangerService.SendMessage(
                mail,
                "Email confirmation",
                $"http://localhost:5000/users/confirm?message={messageToSend}");
        }

        public bool ConfirmEmail(string message)
        {
            var decrypted = EncryptionHelper.Decrypt(message);
            var model = JsonSerializer.Deserialize<ConfirmationMessageModel>(decrypted);
            return mailService.ConfirmMail(model);
        }

        public UserDTO GetUserByLoginAndPassword(AuthenticationModel authenticationModel)
        {
            return userRepository.GetUserByAuthData(authenticationModel);
        }

        public IEnumerable<string> GetUserRolesById(Guid id)
        {
            return userRepository.GetUserRolesById(id);
        }

        public bool RegisterUser(UserDTO userToRegister)
        {
            try
            {
                userToRegister.Id = Guid.NewGuid();
                userRepository.RegisterUser(userToRegister);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
