namespace DbC.Net.Tests.Unit.Utility;

public class StringUtilitiesExtensions
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
   public void StringUtilities_IsAlphaNumericOnly_ShouldReturnTrue_WhenValueContainsOnlyLetterOrDigitCharacters(String value)
      => value.IsAlphaNumericOnly().Should().BeTrue();

   [Fact]
   public void StringUtilities_IsAlphaNumericOnly_ShouldReturnTrue_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;

      // Act/assert.
      value.IsAlphaNumericOnly().Should().BeTrue();
   }

   [Fact]
   public void StringUtilities_IsAlphaNumericOnly_ShouldReturnTrue_WhenValueIsEmpty()
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
   public void StringUtilities_IsAlphaNumericOnly_ShouldReturnTrue_WhenValueContainsNonLetterOrNonDigitCharacters(String value)
      => value.IsAlphaNumericOnly().Should().BeFalse();

   #endregion

   #region IsDigitsOnly Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StringUtilities_IsDigitsOnly_ShouldReturnTrue_WhenValueContainsOnlyDigitCharacters()
   {
      // Arrange.
      var value = "1234567890";

      // Act/assert.
      value.IsDigitsOnly().Should().BeTrue();
   }

   [Fact]
   public void StringUtilities_IsDigitsOnly_ShouldReturnTrue_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;

      // Act/assert.
      value.IsDigitsOnly().Should().BeTrue();
   }

   [Fact]
   public void StringUtilities_IsDigitsOnly_ShouldReturnTrue_WhenValueIsEmpty()
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
   public void StringUtilities_IsDigitsOnly_ShouldReturnTrue_WhenValueContainsNonDigitCharacters(String value)
      => value.IsDigitsOnly().Should().BeFalse();

   #endregion
}
