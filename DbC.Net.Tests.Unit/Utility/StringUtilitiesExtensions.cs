using DbC.Net.Utility;

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
}
