// Ignore Spelling: Luhn

namespace DbC.Net.Tests.Unit.CheckDigits;

public class LuhnAlgorithmTests
{
   private readonly ICheckDigitAlgorithm _sut = StandardCheckDigitAlgorithms.LuhnAlgorithm;

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
      { "0" },                // Empty payload and only a check digit; zero is the only value that works for this case
      { "26" },               // Single character + check digit (tests doubling < 10)
      { "75" },               // Single character + check digit (tests doubling > 10)
      { "133" },              // Two characters + check digit (tests without doubling)
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

   #region ValidateCheckDigit Method Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [MemberData(nameof(TestValuesWithTrailingCheckDigits))]
   public void LuhnAlgorithm_ValidateCheckDigit_ShouldReturnTrue_WhenValueContainsValidCheckDigit(String value)
      => _sut.ValidateCheckDigit(value).Should().BeTrue();

   [Theory]
   [MemberData(nameof(TestValuesWithTrailingCheckDigits))]
   public void LuhnAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueContainsInvalidCheckDigit(String value)
   {
      // Arrange.
      var checkDigit = value[^1] switch
      {
         '0' => '1',
         '1' => '2',
         '2' => '3',
         '3' => '4',
         '4' => '5',
         '5' => '6',
         '6' => '7',
         '7' => '8',
         '8' => '9',
         '9' => '0',
         _ => '?'
      };
      value = value[..^1] + checkDigit;
      
      // Act.
      var result = _sut.ValidateCheckDigit(value);

      // Assert.
      result.Should().BeFalse();
   }

   [Theory]
   [InlineData(null)]
   [InlineData("")]
   [InlineData("5")]
   public void LuhnAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueIsTooShort(String value)
      => _sut.ValidateCheckDigit(value).Should().BeFalse();

   [Theory]
   [InlineData("11/22")]
   [InlineData("11:22")]
   [InlineData("123A789")]
   [InlineData("4012 8888 8888 1881")]
   public void LuhnAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueContainsNonDigitCharacters(String value)
      => _sut.ValidateCheckDigit(value).Should().BeFalse();

   #endregion
}
