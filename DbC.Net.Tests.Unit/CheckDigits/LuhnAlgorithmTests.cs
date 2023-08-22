// Ignore Spelling: Luhn

using System.Security.Cryptography.X509Certificates;

using Xunit.Sdk;

namespace DbC.Net.Tests.Unit.CheckDigits;

public class LuhnAlgorithmTests
{
   private readonly LuhnAlgorithm _sut = new();

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
   [InlineData("2", "6")]
   [InlineData("7992739871", "3")]      // Example from Wikipedia
   [InlineData("49015420323751", "8")]  // Example IMEI (International Mobile Equipment Identity)
   [InlineData("80840123456789", "3")]  // Example NPI (National Provider Identifier)
   public void LuhnAlgorithm_GetCheckDigit_ShouldReturnExpectedResult_WhenValueIsNotEmpty(
      String value,
      String expectedCheckDigit)
   {
      // Arrange.
      var range = value.AsSpan();

      // Act.
      var result = _sut.GetCheckDigit(range);

      // Assert.
      result.Should().Be(expectedCheckDigit);
   }

   [Fact]
   public void LuhnAlgorithm_GetCheckDigit_ShouldThrowArgumentException_WhenValueIsEmpty()
   {
      // Arrange.
      var value = "".AsSpan();

      // Act.
      ArgumentException exception = null!;
      try
      {
         _ = _sut.GetCheckDigit(value);
      }
      catch(ArgumentException ex)
      {
         exception = ex;
      }

      // Assert.
      exception.Should().NotBeNull();
      exception.Message.Should().StartWith(Messages.LuhnAlgorithmValueIsEmpty);
      exception.ParamName.Should().Be(nameof(value));
   }

   [Theory]
   [InlineData("/")]
   [InlineData(":")]
   [InlineData("123A789")]
   public void LuhnAlgorithm_GetCheckDigit_ShouldThrowArgumentException_WhenValueContainsNonDigitCharacters(String value)
   {
      // Arrange.
      var range = value.AsSpan();

      // Act.
      ArgumentException exception = null!;
      try
      {
         _ = _sut.GetCheckDigit(range);
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
