using PasswordGenerator;
using System;
using System.Linq;
using Xunit;

namespace Test;

public class PasswordGeneratorServiceTest
{
    public PasswordGeneratorServiceTest() { }


    [Fact]
    public void BuildPasswordCharSet_OnlyLowerCaseLetters()
    {
        //Arrange
        IPasswordGeneratorService passwordGenerator = new PasswordGeneratorService();

        //Act
        var charSet = passwordGenerator.BuildPasswordCharSet(false, false, false);
        
        //Assert
        Assert.Equal(Constants.LowercaseLetters.Length, charSet.Length);
        Assert.True(charSet.All(Constants.LowercaseLetters.Contains));
    }

    [Theory]
    [InlineData(8, Constants.LowercaseLetters)]
    [InlineData(8, Constants.Numbers)]
    [InlineData(12, Constants.CapitalLetters)]
    [InlineData(12, Constants.SpecialChars)]
    [InlineData(20, Constants.LowercaseLetters + Constants.CapitalLetters + Constants.Numbers + Constants.SpecialChars)]
    public void GeneratePassword(int passwordLength, string charSet)
    {
        //Arrange
        IPasswordGeneratorService passwordGenerator = new PasswordGeneratorService();

        //Act
        var password = passwordGenerator.GeneratePassword(passwordLength, charSet);

        //Assert
        Assert.Equal(passwordLength, password.Length);
        Assert.True(password.All(c => charSet.Contains(c)));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void GeneratePassword_ExceptionExpected(string charSet)
    {
        //Arrange
        IPasswordGeneratorService passwordGenerator = new PasswordGeneratorService();

        //Act
        var function = () => passwordGenerator.GeneratePassword(8, charSet);

        //Assert
        var exception = Assert.Throws<ArgumentException>(function);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void GeneratePassword_MinPasswordLength(int passwordLength)
    {
        //Arrange
        IPasswordGeneratorService passwordGenerator = new PasswordGeneratorService();
        var charSet = Constants.LowercaseLetters + Constants.CapitalLetters + Constants.Numbers + Constants.SpecialChars;

        //Act
        var password = passwordGenerator.GeneratePassword(passwordLength, charSet);

        //Assert
        Assert.Equal(Constants.PasswordMinLength, password.Length);
    }
}