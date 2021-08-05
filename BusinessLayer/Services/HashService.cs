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
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: stringToBeHashed,
                salt: Convert.FromBase64String(hashSettings.PasswordSalt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: hashSettings.IterationCount,
                numBytesRequested: hashSettings.NumberBytesRequested));
        }
    }
}
