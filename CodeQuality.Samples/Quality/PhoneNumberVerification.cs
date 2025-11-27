using FluentAssertions;

namespace CodeQuality.Samples.Quality;

public class PhoneNumberVerification
{
    public static bool ParsePhoneNumber(string phoneNumber)
    {
        if (phoneNumber is not {Length: not (< 8 or > 15)})
            return false;
        if (!phoneNumber.StartsWith("+"))
            return false;
        for (var i = 1; i < phoneNumber.Length; i++)
            if (!int.TryParse(phoneNumber[i].ToString(), out _))
                return false;

        return true;
    }
}

public class PhoneNumberVerificationTest
{
    [Fact]
    public void ShouldReturnFalse_GivenValueIsNull() => PhoneNumberVerification.ParsePhoneNumber(null).Should().BeFalse();
    
    [Fact]
    public void ShouldReturnFalse_GivenValueIsEmpty() => PhoneNumberVerification.ParsePhoneNumber(string.Empty).Should().BeFalse();
    
    [Theory]
    [InlineData("1")]
    [InlineData("12")]
    [InlineData("123")]
    [InlineData("1234")]
    [InlineData("12345")]
    [InlineData("123456")]
    [InlineData("1234567")]
    public void ShouldReturnFalse_GivenLengthIsLowerThan8(string input) => PhoneNumberVerification.ParsePhoneNumber(input).Should().BeFalse();
    
    [Theory]
    [InlineData("1234567890123456")]
    public void ShouldReturnFalse_GivenLengthIsHigherThan15(string input) => PhoneNumberVerification.ParsePhoneNumber(input).Should().BeFalse();
    
    [Fact]
    public void ShouldReturnFalse_GivenDoesNotStartWithPlusSign() => PhoneNumberVerification.ParsePhoneNumber("123456789").Should().BeFalse();
    
    [Fact]
    public void ShouldReturnFalse_GivenNotAllCharactersAreNumerics() => PhoneNumberVerification.ParsePhoneNumber("+1a34!6789").Should().BeFalse();
    
    [Fact]
    public void ShouldReturnTrue_GivenValueIsValidE164() => PhoneNumberVerification.ParsePhoneNumber("+123456789").Should().BeTrue();
}