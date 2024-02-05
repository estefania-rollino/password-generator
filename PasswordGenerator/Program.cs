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

            Console.WriteLine("¿Incluir Mayúsculas? (Y/n): ");
            var includeCapitalLettersValue = Console.ReadLine()?.ToLower();
            var includeCapitalLetters = string.IsNullOrEmpty(includeCapitalLettersValue) || includeCapitalLettersValue == "y" || includeCapitalLettersValue == "yes";

            Console.WriteLine("¿Incluir números? (Y/n): ");
            var includeNumbersValue = Console.ReadLine()?.ToLower();
            var includeNumbers = string.IsNullOrEmpty(includeNumbersValue) || includeNumbersValue == "y" || includeNumbersValue == "yes";

            Console.WriteLine("¿Incluir caracteres especiales? (Y/n): ");
            var includeSpecialCharsValue = Console.ReadLine()?.ToLower();
            var includeSpecialChars = string.IsNullOrEmpty(includeSpecialCharsValue) || includeSpecialCharsValue == "y" || includeSpecialCharsValue == "yes";

            var minLength = 4;
            Console.WriteLine($"Ingresa la longitud de la contraseña (mínimo {minLength}): ");
            var input = Console.ReadLine();
            int.TryParse(input, out int passLength);
            if (passLength < minLength)
                passLength = minLength;

            var charSet = new StringBuilder(lowercaseLetters);

            if (includeCapitalLetters)
                charSet.Append(capitalLetters);

            if (includeNumbers)
                charSet.Append(numbers);

            if (includeSpecialChars)
                charSet.Append(specialChars);

            var random = new Random();
            var generatedPassword = "";
            for (var i = 0; i < passLength; i++)
            {
                var index = random.Next(charSet.Length);
                generatedPassword += charSet[index];
            }
            Console.WriteLine("Password: ");
            Console.WriteLine(generatedPassword);

            Console.ReadKey();
        }
    }
}