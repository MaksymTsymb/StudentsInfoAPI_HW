using System;
using System.Text;

namespace BusinessLayer.Helpers
{
    public static class StringGenerator
    {
        private static readonly Random random;

        static StringGenerator()
        {
            random = new Random();
        }   

        public static string GenerateString(int minLength = 1, int maxLength = 20)
        {
            var messageLength = random.Next(minLength, maxLength);
            var generatedString = new StringBuilder(string.Empty);
            for (int i = 0; i < messageLength; i++)
            {
                generatedString.Append(GetRandomChar());
            }

            return generatedString.ToString();
        }

        private static char GetRandomChar()
        {
            char result = ' ';
            switch (random.Next(1, 3))
            {
                case 1:
                    result = (char)random.Next('A', 'Z');
                    break;
                case 2:
                    result = (char)random.Next('a', 'z');
                    break;
                case 3:
                    result = (char)random.Next('0', '9');
                    break;
            }

            return result;
        }
    }
}