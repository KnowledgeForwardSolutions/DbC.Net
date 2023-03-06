namespace DbC.Net.Tests.Unit.FloatingPoint;

public class StandardFloatingPointComparersTests
{
   #region DecimalFixedErrorComparer Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardFloatingPointComparers_DecimalFixedErrorComparer_ShouldNotBeNull()
      => StandardFloatingPointComparers.DecimalFixedErrorComparer.Should().NotBeNull();

   #endregion

   #region DoubleFixedErrorComparer Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardFloatingPointComparers_DoubleFixedErrorComparer_ShouldNotBeNull()
      => StandardFloatingPointComparers.DoubleFixedErrorComparer.Should().NotBeNull();

   #endregion

   #region HalfFixedErrorComparer Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardFloatingPointComparers_HalfFixedErrorComparer_ShouldNotBeNull()
      => StandardFloatingPointComparers.HalfFixedErrorComparer.Should().NotBeNull();

   #endregion

   #region SingleFixedErrorComparer Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardFloatingPointComparers_SingleFixedErrorComparer_ShouldNotBeNull()
      => StandardFloatingPointComparers.SingleFixedErrorComparer.Should().NotBeNull();

   #endregion

   #region DoubleRelativeErrorComparer Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardFloatingPointComparers_DoubleRelativeErrorComparer_ShouldNotBeNull()
      => StandardFloatingPointComparers.DoubleRelativeErrorComparer.Should().NotBeNull();

   #endregion

   #region HalfRelativeErrorComparer Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardFloatingPointComparers_HalfRelativeErrorComparer_ShouldNotBeNull()
      => StandardFloatingPointComparers.HalfRelativeErrorComparer.Should().NotBeNull();

   #endregion

   #region SingleRelativeErrorComparer Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardFloatingPointComparers_SingleRelativeErrorComparer_ShouldNotBeNull()
      => StandardFloatingPointComparers.SingleRelativeErrorComparer.Should().NotBeNull();

   #endregion
}
