namespace DbC.Net.Tests.Unit.CheckDigits;

public class Isbn10AlgorithmTests
{
   private readonly Isbn10Algorithm _sut = new();

   #region Name Property Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void Isbn10Algorithm_Name_ShouldReturnExpectedValue()
      => _sut.Name.Should().Be("ISBN-10");

   #endregion

   #region ValidateCheckDigit Method Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData("1568656521")]    // Island in the Stream of Time, S. M. Sterling
   [InlineData("0441005608")]    // The Warlock in Spite of Himself, Christopher Stasheff
   [InlineData("0714105449")]    // The Sutton Hoo Ship Burial, Angela Care Evans
   [InlineData("050027293X")]    // Roman London, Peter Marsden
   //
   [InlineData("0306406152")]    // Worked example from Wikipedia article (https://en.wikipedia.org/wiki/ISBN#ISBN-10_check_digits)
   [InlineData("0000000000")]
   public void Isbn10Algorithm_ValidateCheckDigit_ShouldReturnTrue_WhenValueContainsValidCheckDigit(String value)
      => _sut.ValidateCheckDigit(value).Should().BeTrue();

   [Fact]
   public void Isbn10Algorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueContainsInvalidCheckDigit()
   {
      // Arrange.
      var value = "0500272938";

      // Act.
      var result = _sut.ValidateCheckDigit(value);

      // Assert.
      result.Should().BeFalse();
   }

   [Fact]
   public void Isbn10Algorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueContainsLowerCaseXCheckDigitInsteadOfUpperCase()
      => _sut.ValidateCheckDigit("050027293x").Should().BeFalse();

   [Fact]
   public void Isbn10Algorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueIsNull()
      => _sut.ValidateCheckDigit(null!).Should().BeFalse();

   [Fact]
   public void Isbn10Algorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueIsEmpty()
      => _sut.ValidateCheckDigit(String.Empty).Should().BeFalse();

   [Fact]
   public void Isbn10Algorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueHasLessThan10Characters()
      => _sut.ValidateCheckDigit("123456789").Should().BeFalse();

   [Fact]
   public void Isbn10Algorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueMoreThanThan10Characters()
      => _sut.ValidateCheckDigit("1234567890123").Should().BeFalse();

   [Theory]
   [InlineData("          ")]
   [InlineData("03064061-2")]
   [InlineData("03064061 2")]
   [InlineData("03064061:2")]
   [InlineData("0306406G52")]    // The 'G' will calculate to the correct check digit, but should fail because it's not a digit (0-9)
   public void Isbn10Algorithm_ValidateCheckDigit_ShouldReturnFalse_WhenValueContainsNonDigitCharacterOtherThanXCheckDigit(String value)
      => _sut.ValidateCheckDigit(value).Should().BeFalse();

   #endregion
}
