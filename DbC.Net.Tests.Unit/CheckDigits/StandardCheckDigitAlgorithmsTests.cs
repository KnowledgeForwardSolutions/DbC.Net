// Ignore Spelling: Luhn Barcode Aba Npi Verhoeff

namespace DbC.Net.Tests.Unit.CheckDigits;

public class StandardCheckDigitAlgorithmsTests
{
   #region AbaRoutingNumberAlgorithm Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardCheckDigitAlgorithms_AbaRoutingNumberAlgorithm_ShouldNotBeNull()
      => StandardCheckDigitAlgorithms.AbaRoutingNumberAlgorithm.Should().NotBeNull();

   [Fact]
   public void StandardCheckDigitAlgorithms_AbaRoutingNumberAlgorithm_ShouldBeExpectedType()
      => StandardCheckDigitAlgorithms.AbaRoutingNumberAlgorithm.Should().BeOfType<AbaRoutingNumberAlgorithm>();

   #endregion

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

   #region NpiAlgorithm Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardCheckDigitAlgorithms_NpiAlgorithm_ShouldNotBeNull()
      => StandardCheckDigitAlgorithms.NpiAlgorithm.Should().NotBeNull();

   [Fact]
   public void StandardCheckDigitAlgorithms_NpiAlgorithm_ShouldBeExpectedType()
      => StandardCheckDigitAlgorithms.NpiAlgorithm.Should().BeOfType<NpiAlgorithm>();

   #endregion

   #region VehicleIdentificationNumberAlgorithm Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardCheckDigitAlgorithms_VehicleIdentificationNumberAlgorithm_ShouldNotBeNull()
      => StandardCheckDigitAlgorithms.VehicleIdentificationNumberAlgorithm.Should().NotBeNull();

   [Fact]
   public void StandardCheckDigitAlgorithms_VehicleIdentificationNumberAlgorithm_ShouldBeExpectedType()
      => StandardCheckDigitAlgorithms.VehicleIdentificationNumberAlgorithm.Should().BeOfType<VehicleIdentificationNumberAlgorithm>();

   #endregion

   #region VerhoeffAlgorithm Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardCheckDigitAlgorithms_VerhoeffAlgorithm_ShouldNotBeNull()
      => StandardCheckDigitAlgorithms.VerhoeffAlgorithm.Should().NotBeNull();

   [Fact]
   public void StandardCheckDigitAlgorithms_VerhoeffAlgorithm_ShouldBeExpectedType()
      => StandardCheckDigitAlgorithms.VerhoeffAlgorithm.Should().BeOfType<VerhoeffAlgorithm>();

   #endregion
}
