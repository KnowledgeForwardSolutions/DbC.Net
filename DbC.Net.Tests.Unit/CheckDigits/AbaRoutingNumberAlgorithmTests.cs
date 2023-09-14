// Ignore Spelling: Aba

namespace DbC.Net.Tests.Unit.CheckDigits;

public class AbaRoutingNumberAlgorithmTests
{
   private readonly ICheckDigitAlgorithm _sut = StandardCheckDigitAlgorithms.AbaRoutingNumberAlgorithm;

   #region Name Property Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void AbaRoutingNumberAlgorithm_Name_ShouldReturnExpectedValue()
      => _sut.Name.Should().Be("ABA");

   #endregion

   #region ValidateCheckDigit Method Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData("111000025")]     // Worked example from Wikipedia (https://en.wikipedia.org/wiki/ABA_routing_transit_number#Check_digit)
   [InlineData("122235821")]     // US Bank
   [InlineData("325081403")]     // BECU
   [InlineData("325070760")]     // Chase - Washington
   [InlineData("325272021")]     // Alaska USA Federal Credit Union
   //
   [InlineData("000000000")]     // Dummy data - all zeros should have sum mod 10 = zero
   public void AbaRoutingNumberAlgorithm_ValidateCheckDigit_ShouldReturnTrue_WhenValueContainsValidCheckDigit(String value)
      => _sut.ValidateCheckDigit(value).Should().BeTrue();

   [Fact]
   public void AbaRoutingNumberAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueContainsInvalidCheckDigit()
      => _sut.ValidateCheckDigit("111020025").Should().BeFalse();

   [Fact]
   public void AbaRoutingNumberAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueIsNull()
      => _sut.ValidateCheckDigit(null!).Should().BeFalse();

   [Fact]
   public void AbaRoutingNumberAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueIsEmpty()
      => _sut.ValidateCheckDigit(String.Empty).Should().BeFalse();

   [Fact]
   public void AbaRoutingNumberAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueHasLessThan9Characters()
      => _sut.ValidateCheckDigit("000000").Should().BeFalse();

   [Fact]
   public void AbaRoutingNumberAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueMoreThanThan9Characters()
      => _sut.ValidateCheckDigit("000000000000").Should().BeFalse();

   [Theory]
   [InlineData("         ")]
   [InlineData("00D000000")]       // The 'D' will calculate to the correct check digit, but should fail because it's not a digit (0-9)
   public void AbaRoutingNumberAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueContainsNonDigitCharacter(String value)
      => _sut.ValidateCheckDigit(value).Should().BeFalse();

   #endregion
}
