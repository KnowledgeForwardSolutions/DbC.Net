// Ignore Spelling: Barcode

namespace DbC.Net.Tests.Unit.CheckDigits;

public class Mod10BarcodeAlgorithmTests
{
   private readonly ICheckDigitAlgorithm _sut = StandardCheckDigitAlgorithms.Mod10BarcodeAlgorithm;

   #region Name Property Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void Mod10BarcodeAlgorithm_Name_ShouldReturnExpectedValue()
      => _sut.Name.Should().Be("Mod10Barcode");

   #endregion

   #region ValidateCheckDigit Method Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData("036000291452")]        // Worked UPC-A example from Wikipedia (https://en.wikipedia.org/wiki/Universal_Product_Code#Check_digit_calculation)
   [InlineData("425261")]              // UPC-E example
   [InlineData("4006381333931")]       // Worked EAN-13 example from Wikipedia (https://en.wikipedia.org/wiki/International_Article_Number)
   [InlineData("73513537")]            // Worked EAN-8 example from Wikipedia
   [InlineData("9780500516959")]       // ISBN-13, Islamic Geometric Design, Eric Broug
   [InlineData("012345678000045678")]  // Example SSCC number
   
   // Edge cases
   [InlineData("31")]                  // Single character + check digit (tests odd number summing)
   [InlineData("123")]                 // Two characters + check digit (tests even number summing)
   [InlineData("130")]                 // Tests for when sum mod 10 is zero
   [InlineData("84130")]               // "
   [InlineData("000000")]              // "
   [InlineData("00000000")]            // "
   [InlineData("0000000000000")]       // "
   public void Mod10BarcodeAlgorithm_ValidateCheckDigit_ShouldReturnTrue_WhenValueContainsValidCheckDigit(String value)
      => _sut.ValidateCheckDigit(value).Should().BeTrue();

   [Fact]
   public void Mod10BarcodeAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueContainsInvalidCheckDigit()
      => _sut.ValidateCheckDigit("4006381333932").Should().BeFalse();

   [Fact]
   public void Mod10BarcodeAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueIsNull()
      => _sut.ValidateCheckDigit(null!).Should().BeFalse();

   [Fact]
   public void Mod10BarcodeAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueIsEmpty()
      => _sut.ValidateCheckDigit(String.Empty).Should().BeFalse();

   [Theory]
   [InlineData("      ")]
   [InlineData("0 36000 29145 2")]     // UPC-A with separator characters - non digit characters not allowed
   [InlineData("979-0-2600-0043-8")]   // ISMN with separator characters - non digit characters not allowed
   [InlineData("400638E333931")]       // The 'G' will calculate to the correct check digit, but should fail because it's not a digit (0-9)
   public void Mod10BarcodeAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueContainsNonDigitCharacter(String value)
      => _sut.ValidateCheckDigit(value).Should().BeFalse();

   #endregion
}
