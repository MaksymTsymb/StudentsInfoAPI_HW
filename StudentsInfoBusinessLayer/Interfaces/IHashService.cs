namespace BusinessLayer.Interfaces
{
        public interface IHashService
        {
            string HashString(string stringToBeHashed);
            bool ValidateHash(string hashedString, string stringToBeHashed);
        }
}
