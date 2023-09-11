namespace DbC.Net.Tests.Unit.CheckDigits;

public class VehicleIdentificationNumberAlgorithmTests
{
   private readonly VehicleIdentificationNumberAlgorithm _sut = new();

   #region Name Property Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void VehicleIdentificationNumberAlgorithm_Name_ShouldReturnExpectedValue()
      => _sut.Name.Should().Be("VIN");

   #endregion

   #region ValidateCheckDigit Method Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData("1M8GDM9AXKP042788")]   // Worked example from Wikipedia (https://en.wikipedia.org/wiki/Vehicle_identification_number#Check-digit_calculation)
   //
   [InlineData("11111111111111111")]   // Test value as per Wikipedia 
   [InlineData("1G8ZG127XWZ157259")]   // Random VIN from https://vingenerator.org/
   [InlineData("1HGEM21292L047875")]   // "
   public void VehicleIdentificationNumberAlgorithm_ValidateCheckDigit_ShouldReturnTrue_WhenValueContainsValidCheckDigit(String value)
      => _sut.ValidateCheckDigit(value).Should().BeTrue();

   [Fact]
   public void VehicleIdentificationNumberAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueContainsInvalidCheckDigit()
      => _sut.ValidateCheckDigit("11111111111111112").Should().BeFalse();

   [Fact]
   public void VehicleIdentificationNumberAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueIsNull()
      => _sut.ValidateCheckDigit(null!).Should().BeFalse();

   [Fact]
   public void VehicleIdentificationNumberAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueIsEmpty()
      => _sut.ValidateCheckDigit(String.Empty).Should().BeFalse();

   [Fact]
   public void VehicleIdentificationNumberAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueHasLessThan17Characters()
      => _sut.ValidateCheckDigit("1111111111111111").Should().BeFalse();

   [Fact]
   public void VehicleIdentificationNumberAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueMoreThanThan17Characters()
      => _sut.ValidateCheckDigit("111111111111111111").Should().BeFalse();

   [Theory]
   [InlineData("                 ")]
   [InlineData("1234567890123456A")]
   public void VehicleIdentificationNumberAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueContainsNonDigitCharacter(String value)
      => _sut.ValidateCheckDigit(value).Should().BeFalse();

   #endregion
}
