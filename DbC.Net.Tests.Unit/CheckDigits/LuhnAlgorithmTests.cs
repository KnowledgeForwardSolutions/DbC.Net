// Ignore Spelling: Luhn

using FluentAssertions.Formatting;

namespace DbC.Net.Tests.Unit.CheckDigits;

public class LuhnAlgorithmTests
{
   private readonly ICheckDigitAlgorithm _sut = StandardCheckDigitAlgorithms.LuhnAlgorithm;

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
   [InlineData("0000000018")]
   [InlineData("0000001008")]
   [InlineData("0000100008")]
   [InlineData("0010000008")]
   [InlineData("1000000008")]
   public void LuhnAlgorithm_ValidateCheckDigit_ShouldReturnTrue_WhenAlgorithmDoublesOddPositions(String value)
      => _sut.ValidateCheckDigit(value).Should().BeTrue();

   [Theory]
   [InlineData("0000000109")]
   [InlineData("0000010009")]
   [InlineData("0001000009")]
   [InlineData("0100000009")]
   public void LuhnAlgorithm_ValidateCheckDigit_ShouldReturnTrue_WhenAlgorithmDoesNotDoubleEvenPositions(String value)
      => _sut.ValidateCheckDigit(value).Should().BeTrue();

   [Theory]
   [InlineData("00")]
   [InlineData("18")]
   [InlineData("26")]
   [InlineData("34")]
   [InlineData("42")]
   [InlineData("59")]
   [InlineData("67")]
   [InlineData("75")]
   [InlineData("83")]
   [InlineData("91")]
   public void LuhnAlgorithm_ValidateCheckDigit_ShouldReturnTrue_WhenDoublingTableEntriesAreCorrect(String value)
      => _sut.ValidateCheckDigit(value).Should().BeTrue();

   [Theory]
   [InlineData("378282246310005")]     // American Express test credit card number
   [InlineData("6011111111111117")]    // Discover test credit card number
   [InlineData("5555555555554444")]    // MasterCard test credit card number
   [InlineData("4012888888881881")]    // Visa test credit card number
   [InlineData("3056930009020004")]    // Diners Club test credit card number
   [InlineData("3566111111111113")]    // JCB test credit card number
   [InlineData("808401234567893")]     // NPI (National Provider Identifier), including 80840 prefix
   [InlineData("490154203237518")]     // IMEI (International Mobile Equipment Identity)
   public void LuhnAlgorithm_ValidateCheckDigit_ShouldReturnTrue_WhenValueContainsValidCheckDigit(String value)
      => _sut.ValidateCheckDigit(value).Should().BeTrue();

   [Theory]
   [InlineData("3056930090020004")]    // Diners Club test card number with two digit transposition 09 -> 90
   [InlineData("3056930000920004")]    // Diners Club test card number with two digit transposition 90 -> 09
   [InlineData("5555555225554444")]    // MasterCard test card number with two digit twin error 55 -> 22
   [InlineData("5555555225554774")]    // MasterCard test card number with two digit twin error 44 -> 77
   [InlineData("3533111111111113")]    // JCB test card number with two digit twin error 66 -> 33
   public void LuhnAlgorithm_ValidateCheckDigit_ShouldReturnTrue_WhenValueContainsUndetectableError(String value)
      => _sut.ValidateCheckDigit(value).Should().BeTrue();

   [Theory]
   [InlineData("5558555555554444")]    // MasterCard test card number with single digit transcription error 5 -> 8
   [InlineData("5558555555554434")]    // MasterCard test card number with single digit transcription error 4 -> 3
   [InlineData("3059630009020004")]    // Diners Club test card number with two digit transposition error 69 -> 96 
   [InlineData("3056930009002004")]    // Diners Club test card number with two digit transposition error 20 -> 02
   [InlineData("5559955555554444")]    // MasterCard test card number with two digit twin error 55 -> 99
   [InlineData("3566111144111113")]    // JCB test card number with two digit twin error 11 -> 44
   public void LuhnAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenInputContainsDetectableError(String value)
      => _sut.ValidateCheckDigit(value).Should().BeFalse();

   [Fact]
   public void LuhnAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenInputIsNull()
      => _sut.ValidateCheckDigit(null!).Should().BeFalse();

   [Fact]
   public void LuhnAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenInputIsEmpty()
      => _sut.ValidateCheckDigit(String.Empty).Should().BeFalse();

   [Fact]
   public void LuhnAlgorithm_ValidateCheckDigit_ShouldReturnTrue_WhenInputIsAllZeros()
      => _sut.ValidateCheckDigit("0000000000000000").Should().BeTrue();

   [Fact]
   public void LuhnAlgorithm_ValidateCheckDigit_ShouldReturnTrue_WhenCheckDigitIsCalculatesAsZero()
      => _sut.ValidateCheckDigit("7624810").Should().BeTrue();

   [Theory]
   [InlineData("0")]
   [InlineData("1")]
   public void LuhnAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenInputIsOneCharacterInLength(String value)
      => _sut.ValidateCheckDigit(value).Should().BeFalse();

   [Theory]
   [InlineData("123A780")]
   [InlineData("123A782")]
   [InlineData("123A783")]
   [InlineData("123A784")]
   [InlineData("123A785")]
   [InlineData("123A786")]
   [InlineData("123A787")]
   [InlineData("123A788")]
   [InlineData("123A789")]
   [InlineData("123+780")]
   [InlineData("123+782")]
   [InlineData("123+783")]
   [InlineData("123+784")]
   [InlineData("123+785")]
   [InlineData("123+786")]
   [InlineData("123+787")]
   [InlineData("123+788")]
   [InlineData("123+789")]
   [InlineData("11/22")]
   [InlineData("11:22")]
   [InlineData("4012 8888 8888 1881")]
   public void LuhnAlgorithm_ValidateCheckDigit_ShouldReturnFalse_WhenInputContainsNonDigitCharacter(String value)
      => _sut.ValidateCheckDigit(value).Should().BeFalse();

   #endregion
}
