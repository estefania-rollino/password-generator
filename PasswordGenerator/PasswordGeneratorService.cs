using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public class PasswordGeneratorService : IPasswordGeneratorService
    {
        public PasswordGeneratorService() 
        {
        }

        public string BuildPasswordCharSet(bool includeCapitalLetters, bool includeNumbers, bool includeSpecialChars)
        {
            var charSet = new StringBuilder(Constants.LowercaseLetters);
            if (includeCapitalLetters)
                charSet.Append(Constants.CapitalLetters);

            if (includeNumbers)
                charSet.Append(Constants.Numbers);

            if (includeSpecialChars)
                charSet.Append(Constants.SpecialChars);

            return charSet.ToString();
        }

        public string GeneratePassword(int passwordLength, string charSet)
        {
            if (string.IsNullOrEmpty(charSet))
                throw new ArgumentException($"Char set cannot be null or empty.", nameof(charSet));

            if (passwordLength < Constants.PasswordMinLength)
                passwordLength = Constants.PasswordMinLength;

            var random = new Random();
            var generatedPassword = new StringBuilder();
            for (var i = 0; i < passwordLength; i++)
            {
                var index = random.Next(charSet.Length);
                generatedPassword.Append(charSet[index]);
            }
            return generatedPassword.ToString();
        }
    }
}
