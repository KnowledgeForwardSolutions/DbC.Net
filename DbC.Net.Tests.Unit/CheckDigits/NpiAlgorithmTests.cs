// Ignore Spelling: Npi

namespace DbC.Net.Tests.Unit.CheckDigits;

public class NpiAlgorithmTests
{
   private readonly ICheckDigitAlgorithm _sut = StandardCheckDigitAlgorithms.NpiAlgorithm;

   #region Name Property Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void NpiAlgorithm_Name_ShouldReturnExpectedValue()
      => _sut.Name.Should().Be("NPI");

   #endregion

   #region ValidateCheckDigit Method Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData("1234567893")]
   [InlineData("1245319599")]    // Example from www.hippaspace.com

   [InlineData("0000000006")]    // Check digit value comes only from "80840" prefix
   public void NpiAlgorithm_ValidateCheckDigit_ShouldReturnTrue_WhenValueContainsValidCheckDigit(String value)
      => _sut.ValidateCheckDigit(value).Should().BeTrue();

   [Fact]
   public void NpiAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueContainsInvalidCheckDigit()
      => _sut.ValidateCheckDigit("1234567890").Should().BeFalse();

   [Fact]
   public void NpiAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueIsNull()
      => _sut.ValidateCheckDigit(null!).Should().BeFalse();

   [Fact]
   public void NpiAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueIsEmpty()
      => _sut.ValidateCheckDigit(String.Empty).Should().BeFalse();

   [Fact]
   public void NpiAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueHasLessThan10Characters()
      => _sut.ValidateCheckDigit("123456789").Should().BeFalse();

   [Fact]
   public void NpiAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueMoreThanThan10Characters()
      => _sut.ValidateCheckDigit("1234567890123").Should().BeFalse();

   [Theory]
   [InlineData("          ")]
   [InlineData("000 00 006")]
   [InlineData("000:00-006")]
   [InlineData("ABCDEFGHIJ")]
   [InlineData("0000000D06")]    // The 'D' will calculate to the correct check digit, but should fail because it's not a digit (0-9)
   public void NpiAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueContainsNonDigitCharacter(String value)
      => _sut.ValidateCheckDigit(value).Should().BeFalse();

   #endregion
}
