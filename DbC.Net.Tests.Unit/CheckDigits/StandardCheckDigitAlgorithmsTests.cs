// Ignore Spelling: Luhn

namespace DbC.Net.Tests.Unit.CheckDigits;

public class StandardCheckDigitAlgorithmsTests
{
   #region LuhnAlgoIsbn10Algorithmrithm Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardCheckDigitAlgorithms_Isbn10Algorithm_ShouldNotBeNull()
      => StandardCheckDigitAlgorithms.Isbn10Algorithm.Should().NotBeNull();

   [Fact]
   public void StandardCheckDigitAlgorithms_Isbn10Algorithm_ShouldBeExpectedType()
      => StandardCheckDigitAlgorithms.Isbn10Algorithm.Should().BeOfType<Isbn10Algorithm>();

   #endregion

   #region LuhnAlgorithm Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardCheckDigitAlgorithms_LuhnAlgorithm_ShouldNotBeNull()
      => StandardCheckDigitAlgorithms.LuhnAlgorithm.Should().NotBeNull();

   [Fact]
   public void StandardCheckDigitAlgorithms_LuhnAlgorithm_ShouldBeExpectedType()
      => StandardCheckDigitAlgorithms.LuhnAlgorithm.Should().BeOfType<LuhnAlgorithm>();

   #endregion
}
