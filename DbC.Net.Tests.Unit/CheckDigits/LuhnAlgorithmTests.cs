// Ignore Spelling: Luhn

using System.Security.Cryptography.X509Certificates;

using Xunit.Sdk;

namespace DbC.Net.Tests.Unit.CheckDigits;

public class LuhnAlgorithmTests
{
   private readonly LuhnAlgorithm _sut = new();

   public static TheoryData<String> TestValuesWithTrailingCheckDigits = new()
   {
      // Test credit card data from https://kb.blackbaud.com/knowledgebase/articles/Article/64901
      { "378282246310005" },   // American Express
      { "6011111111111117" },  // Discover
      { "5555555555554444" },  // MasterCard
      { "4111111111111111" },  // Visa
      { "3056930009020004" },  // Diners Club
      { "3566111111111113" },  // JCB

      // Non-credit card examples
      { "808401234567893" },  // NPI (National Provider Identifier)
      { "490154203237518" },  // IMEI (International Mobile Equipment Identity)

      // Edge cases
      { "26" },               // Single character + check digit
      { "240" },              // sum Mod 10 result should be zero
      { "7624810" },          // "
      { "0000000000000000" }  // "
   };

   #region Name Property Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void LuhnAlgorithm_Name_ShouldReturnExpectedValue()
      => _sut.Name.Should().Be("Luhn");

   #endregion

   #region GetCheckDigit Method Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [MemberData(nameof(TestValuesWithTrailingCheckDigits))]
   public void LuhnAlgorithm_GetCheckDigit_ShouldReturnExpectedResult_WhenNonEmptyValueIncludesCheckDigit(String value)
   {
      // Arrange.
      var expectedCheckDigit = value[^1].ToString();

      // Act.
      var result = _sut.GetCheckDigit(value);

      // Assert.
      result.Should().Be(expectedCheckDigit);
   }

   [Theory]
   [MemberData(nameof(TestValuesWithTrailingCheckDigits))]
   public void LuhnAlgorithm_GetCheckDigit_ShouldReturnExpectedResult_WhenNonEmptyValueDoesNotIncludeCheckDigit(String value)
   {
      // Arrange.
      var expectedCheckDigit = value[^1].ToString();
      value = value[..(value.Length - 1)];

      // Act.
      var result = _sut.GetCheckDigit(value, false);

      // Assert.
      result.Should().Be(expectedCheckDigit);
   }

   [Fact]
   public void LuhnAlgorithm_GetCheckDigit_ShouldReturnZero_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var expectedCheckDigit = "0";

      // Act.
      var result = _sut.GetCheckDigit(value, false);

      // Assert.
      result.Should().Be(expectedCheckDigit);
   }

   [Theory]
   [InlineData("", true)]
   [InlineData("1", true)]
   [InlineData("", false)]
   public void LuhnAlgorithm_GetCheckDigit_ShouldReturnZero_WhenValueIsTooShort(
      String value,
      Boolean includeCheckDigit)
   {
      // Arrange.
      var expectedCheckDigit = "0";

      // Act.
      var result = _sut.GetCheckDigit(value, includeCheckDigit);

      // Assert.
      result.Should().Be(expectedCheckDigit);
   }

   [Theory]
   [InlineData("/", false)]
   [InlineData(":", false)]
   [InlineData("123A789", false)]
   [InlineData("4012 8888 8888 1881", true)]
   public void LuhnAlgorithm_GetCheckDigit_ShouldThrowArgumentException_WhenValueContainsNonDigitCharacters(
      String value,
      Boolean includesCheckDigit)
   {
      // Arrange.
      var range = value;

      // Act.
      ArgumentException exception = null!;
      try
      {
         _ = _sut.GetCheckDigit(range, includesCheckDigit);
      }
      catch (ArgumentException ex)
      {
         exception = ex;
      }

      // Assert.
      exception.Should().NotBeNull();
      exception.Message.Should().StartWith(Messages.LuhnAlgorithmValueContainsNonDigit);
      exception.ParamName.Should().Be(nameof(value));
   }

   #endregion
}
