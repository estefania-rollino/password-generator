namespace PasswordGenerator
{
    public interface IPasswordGeneratorService
    {
        string BuildPasswordCharSet(bool includeCapitalLetters, bool includeNumbers, bool includeSpecialChars);

        string GeneratePassword(int passwordLength, string charSet);
    }
}