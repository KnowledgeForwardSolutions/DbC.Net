// Ignore Spelling: Luhn

namespace DbC.Net.Tests.Unit.CheckDigits;

public class StandardCheckDigitAlgorithmsTests
{
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
