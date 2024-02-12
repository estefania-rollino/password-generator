using System;

namespace PasswordGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Bienvenidos a PasswordGeneratorService!");

            var includeCapitalLetters = GetUserChoice("¿Incluir Mayúsculas? (Y/n): ");
            var includeNumbers = GetUserChoice("¿Incluir números? (Y/n): ");
            var includeSpecialChars = GetUserChoice("¿Incluir caracteres especiales? (Y/n): ");

            var passwordGenerator = new PasswordGeneratorService();
            var charSet = passwordGenerator.BuildPasswordCharSet(includeCapitalLetters, includeNumbers, includeSpecialChars);
            var passwordLength = RequestPasswordLength();
            var generatedPassword = passwordGenerator.GeneratePassword(passwordLength, charSet);

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
            Console.WriteLine($"Ingresa la longitud de la contraseña (mínimo {Constants.PasswordMinLength}): ");
            var input = Console.ReadLine();
            int.TryParse(input, out int passLength);
            return passLength;
        }
    }
}