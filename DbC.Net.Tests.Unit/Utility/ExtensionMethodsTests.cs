namespace DbC.Net.Tests.Unit.Utility;

public class ExtensionMethodsTests
{
   #region IsAlphaNumericOnly Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData("123")]
   [InlineData("asdf")]
   [InlineData("QWERTY")]
   [InlineData(StringData.UpperCaseDiphthongAE)]
   [InlineData(StringData.LowerCaseAWithOverring)]
   [InlineData("abc123XYZ")]
   [InlineData("s\u00F8ster")]  // s + lower case slashed 'o' + ster - Danish for sister
   public void ExtensionMethods_IsAlphaNumericOnly_ShouldReturnTrue_WhenValueContainsOnlyLetterOrDigitCharacters(String value)
      => value.IsAlphaNumericOnly().Should().BeTrue();

   [Fact]
   public void ExtensionMethods_IsAlphaNumericOnly_ShouldReturnTrue_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;

      // Act/assert.
      value.IsAlphaNumericOnly().Should().BeTrue();
   }

   [Fact]
   public void ExtensionMethods_IsAlphaNumericOnly_ShouldReturnTrue_WhenValueIsEmpty()
   {
      // Arrange.
      var value = String.Empty;

      // Act/assert.
      value.IsAlphaNumericOnly().Should().BeTrue();
   }

   [Theory]
   [InlineData("This is a test!")]
   [InlineData("\t")]
   [InlineData("\tASDF\t")]
   [InlineData(StringData.LowerCaseAPlusDiaeresisCombiningCharacter)]
   public void ExtensionMethods_IsAlphaNumericOnly_ShouldReturnTrue_WhenValueContainsNonLetterOrNonDigitCharacters(String value)
      => value.IsAlphaNumericOnly().Should().BeFalse();

   #endregion

   #region IsDigitsOnly Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ExtensionMethods_IsDigitsOnly_ShouldReturnTrue_WhenValueContainsOnlyDigitCharacters()
   {
      // Arrange.
      var value = "1234567890";

      // Act/assert.
      value.IsDigitsOnly().Should().BeTrue();
   }

   [Fact]
   public void ExtensionMethods_IsDigitsOnly_ShouldReturnTrue_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;

      // Act/assert.
      value.IsDigitsOnly().Should().BeTrue();
   }

   [Fact]
   public void ExtensionMethods_IsDigitsOnly_ShouldReturnTrue_WhenValueIsEmpty()
   {
      // Arrange.
      var value = String.Empty;

      // Act/assert.
      value.IsDigitsOnly().Should().BeTrue();
   }

   [Theory]
   [InlineData("This is a test!")]
   [InlineData("\t")]
   [InlineData(StringData.LowerCaseAPlusDiaeresisCombiningCharacter)]
   [InlineData(StringData.FractionOneTenth)]
   [InlineData(StringData.RomanNumeral12)]
   public void ExtensionMethods_IsDigitsOnly_ShouldReturnTrue_WhenValueContainsNonDigitCharacters(String value)
      => value.IsDigitsOnly().Should().BeFalse();

   #endregion

   #region TransliterateVinChar Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData('0', 0)]
   [InlineData('1', 1)]
   [InlineData('2', 2)]
   [InlineData('3', 3)]
   [InlineData('4', 4)]
   [InlineData('5', 5)]
   [InlineData('6', 6)]
   [InlineData('7', 7)]
   [InlineData('8', 8)]
   [InlineData('9', 9)]
   [InlineData('A', 1)]
   [InlineData('B', 2)]
   [InlineData('C', 3)]
   [InlineData('D', 4)]
   [InlineData('E', 5)]
   [InlineData('F', 6)]
   [InlineData('G', 7)]
   [InlineData('H', 8)]
   [InlineData('J', 1)]
   [InlineData('K', 2)]
   [InlineData('L', 3)]
   [InlineData('M', 4)]
   [InlineData('N', 5)]
   [InlineData('P', 7)]
   [InlineData('R', 9)]
   [InlineData('S', 2)]
   [InlineData('T', 3)]
   [InlineData('U', 4)]
   [InlineData('V', 5)]
   [InlineData('W', 6)]
   [InlineData('X', 7)]
   [InlineData('Y', 8)]
   [InlineData('Z', 9)]
   public void ExtensionMethods_TransliterateVinChar_ShouldReturnExpectedValue_WhenCharacterIsValid(
      Char ch,
      Int32 expected)
      => ch.TransliterateVinChar().Should().Be(expected);

   [Theory]
   [InlineData('/')]
   [InlineData('I')]
   [InlineData('O')]
   [InlineData('Q')]
   [InlineData('a')]
   [InlineData('^')]
   public void ExtensionMethods_TransliterateVinChar_ShouldReturnMinusOne_WhenCharacterIsInvalid(Char ch)
      => ch.TransliterateVinChar().Should().Be(-1);

   #endregion
}
