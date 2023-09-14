// Ignore Spelling: Verhoeff

namespace DbC.Net.Tests.Unit.CheckDigits;

public class VerhoeffAlgorithmTests
{
   private readonly ICheckDigitAlgorithm _sut = StandardCheckDigitAlgorithms.VerhoeffAlgorithm;

   #region Name Property Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void VerhoeffAlgorithm_Name_ShouldReturnExpectedValue()
      => _sut.Name.Should().Be("Verhoeff");

   #endregion

   #region ValidateCheckDigit Method Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData("2363")]                      // Worked example from Wikipedia
   [InlineData("123451")]                    // Test data from https://rosettacode.org/wiki/Verhoeff_algorithm
   [InlineData("1234567890120")]             // "
   [InlineData("758722")]                    // Test data from https://codereview.stackexchange.com/questions/221229/verhoeff-check-digit-algorithm
   [InlineData("1428570")]                   // "
   [InlineData("84736430954837284567892")]   // "
   [InlineData("112233445566778899009")]     // Value calculated by https://kik.amc.nl/home/rcornet/verhoeff.html
   public void VerhoeffAlgorithm_ValidateCheckDigit_ShouldReturnTrue_WhenValueContainsValidCheckDigit(String value)
      => _sut.ValidateCheckDigit(value).Should().BeTrue();

   [Theory]
   [InlineData("112233445566778899019")]     // Single digit errors (using "112233445566778899009" as a valid value)
   [InlineData("112233445566778892009")]     // "
   [InlineData("112233445566778399009")]     // "
   [InlineData("112233445566748899009")]     // "
   [InlineData("112233445565778899009")]     // "
   [InlineData("112233445666778899009")]     // "
   [InlineData("112233475566778899009")]     // "
   [InlineData("112238445566778899009")]     // "
   [InlineData("112933445566778899009")]     // "
   [InlineData("102233445566778899009")]     // "
   [InlineData("121233445566778899009")]     // Transposition errors (using "112233445566778899009" as a valid value)
   [InlineData("112323445566778899009")]     // "
   [InlineData("112234345566778899009")]     // "
   [InlineData("112233454566778899009")]     // "
   [InlineData("112233445656778899009")]     // "
   [InlineData("112233445567678899009")]     // "
   [InlineData("112233445566787899009")]     // "
   [InlineData("112233445566778989009")]     // "
   [InlineData("112233445566778890909")]     // "
   public void VerhoeffAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueContainsInvalidCheckDigit(String value)
      => _sut.ValidateCheckDigit(value).Should().BeFalse();

   [Fact]
   public void VerhoeffAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueIsNull()
      => _sut.ValidateCheckDigit(null!).Should().BeFalse();

   [Fact]
   public void VerhoeffAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueIsEmpty()
      => _sut.ValidateCheckDigit(String.Empty).Should().BeFalse();

   [Fact]
   public void VerhoeffAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueHasLengthLessThanTwo()
      => _sut.ValidateCheckDigit("0").Should().BeFalse();   // "0" is the only digit that would pass unless length is checked explicitly

   [Theory]
   [InlineData("142D570")]
   [InlineData("142/570")]
   [InlineData("142:570")]
   public void VerhoeffAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueContainsNonDigitCharacter(String value)
      => _sut.ValidateCheckDigit(value).Should().BeFalse();

   #endregion
}
