using System;
using System.Text;

namespace PasswordGenerator
{
    internal class Program
    {
        private const string lowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string numbers = "0123456789";
        private const string specialChars = "!@#$%^&*()_-+=<>?/";

        private static void Main(string[] args)
        {
            Console.WriteLine("Bienvenidos a PasswordGenerator!");

            var includeCapitalLetters = GetUserChoice("¿Incluir Mayúsculas? (Y/n): ");
            var includeNumbers = GetUserChoice("¿Incluir números? (Y/n): ");
            var includeSpecialChars = GetUserChoice("¿Incluir caracteres especiales? (Y/n): ");
            var passLength = RequestPasswordLength();

            var charSet = BuildPasswordCharSet(includeCapitalLetters, includeNumbers, includeSpecialChars);
            var generatedPassword = GeneratePassword(passLength, charSet);
            Console.WriteLine("Password: ");
            Console.WriteLine(generatedPassword);

            Console.ReadKey();
        }

        private static bool GetUserChoice(string question)
        {
            Console.WriteLine(question);
            var response = Console.ReadLine()?.ToLower();
            return string.IsNullOrEmpty(response) || response == "y" || response == "yes";
        }

        private static int RequestPasswordLength() 
        {
            const int passwordMinLength = 4;
            Console.WriteLine($"Ingresa la longitud de la contraseña (mínimo {passwordMinLength}): ");
            var input = Console.ReadLine();
            int.TryParse(input, out int passLength);
            if (passLength < passwordMinLength)
                passLength = passwordMinLength;
            return passLength;
        }

        private static string BuildPasswordCharSet(bool includeCapitalLetters, bool includeNumbers, bool includeSpecialChars) 
        {
            var charSet = new StringBuilder(lowercaseLetters);
            if (includeCapitalLetters)
                charSet.Append(capitalLetters);

            if (includeNumbers)
                charSet.Append(numbers);

            if (includeSpecialChars)
                charSet.Append(specialChars);

            return charSet.ToString();
        }

        private static string GeneratePassword(int passwordLength, string charSet) 
        {
            var random = new Random();
            var generatedPassword = "";
            for (var i = 0; i < passwordLength; i++)
            {
                var index = random.Next(charSet.Length);
                generatedPassword += charSet[index];
            }
            return generatedPassword;
        }
    }
}