using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using BusinessLayer.Models;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class HashService : IHashService
    {
        private readonly HashSettings hashSettings;

        public HashService(IOptions<HashSettings> hashSettings)
        {
            this.hashSettings = hashSettings.Value;
        }

        public string HashString(string stringToBeHashed)
        {
            string hashedString;

            var numBytesRequested = hashSettings.NumberBytesRequested;
            var iterationCount = hashSettings.IterationCount;
            var prf = KeyDerivationPrf.HMACSHA1;
            var salt = Convert.FromBase64String(hashSettings.PasswordSalt);
            var pbkdf2MethodResult = KeyDerivation.Pbkdf2(stringToBeHashed, salt, prf, iterationCount, numBytesRequested);
            hashedString = Convert.ToBase64String(pbkdf2MethodResult);

            return hashedString;
            }
    }
}
