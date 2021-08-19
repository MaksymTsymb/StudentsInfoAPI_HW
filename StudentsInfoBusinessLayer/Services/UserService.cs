using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
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
        private readonly IUserRolesRepository userRolesRepository;

        public UserService(
            IUserRepository userRepository,
            IMailService mailService,
            IMailExchangerService mailExchangerService,
            IMapper mapper,
            IUserRolesRepository userRolesRepository)
        {
            this.userRepository = userRepository;
            this.mailService = mailService;
            this.mailExchangerService = mailExchangerService;
            this.mapper = mapper;
            this.userRolesRepository = userRolesRepository;
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
            var confirmationString = $"http://localhost:5000/users/confirm?message={messageToSend}";

            mailExchangerService.SendMessage(
                mail,
                "Email confirmation", confirmationString);

            WriteStringToFile(confirmationString);
        }

        public ConfirmationResult ConfirmEmail(string message)
        {
            try
            {
                var decrypted = EncryptionHelper.Decrypt(message);
                var model = JsonSerializer.Deserialize<ConfirmationMessageModel>(decrypted);
                var isSuccessful = mailService.ConfirmMail(model);
                return new ConfirmationResult
                {
                    IsSuccessful = isSuccessful,
                    UserId = model.UserId
                };
            }
            catch (Exception ex)
            {
                return new ConfirmationResult { IsSuccessful = false };
            }

        }

        public bool AddUserRole(AssigningRoleModel addUserRoleModel)
        {
            var result = userRolesRepository.AddUserRole(addUserRoleModel);
            userRepository.AddUserRole(addUserRoleModel);

            return result;
        }
        public UserDTO GetUserByLoginAndPassword(AuthenticationModel authenticationModel)
        {
            return userRepository.GetUserByAuthData(authenticationModel);
        }

        public IEnumerable<string> GetUserRolesById(Guid id)
        {
            return userRepository.GetUserRolesById(id);
        }

        private void WriteStringToFile(string message)
        {
            using (var streamWriter = new StreamWriter("confirmationString.txt"))
            {
                streamWriter.WriteLine(message);
            }
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
