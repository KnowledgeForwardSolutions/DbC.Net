// Ignore Spelling: Luhn Barcode

namespace DbC.Net.Tests.Unit.CheckDigits;

public class StandardCheckDigitAlgorithmsTests
{
   #region Isbn10Algorithm Tests
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

   #region Mod10BarcodeAlgorithm Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardCheckDigitAlgorithms_Mod10BarcodeAlgorithm_ShouldNotBeNull()
      => StandardCheckDigitAlgorithms.Mod10BarcodeAlgorithm.Should().NotBeNull();

   [Fact]
   public void StandardCheckDigitAlgorithms_Mod10BarcodeAlgorithm_ShouldBeExpectedType()
      => StandardCheckDigitAlgorithms.Mod10BarcodeAlgorithm.Should().BeOfType<Mod10BarcodeAlgorithm>();

   #endregion
}
