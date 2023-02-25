namespace DbC.Net.Tests.Unit.FloatingPoint;

public class StandardFloatingPointComparersTests
{
   #region DecimalFixedEpsilonComparer Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardFloatingPointComparers_DecimalFixedEpsilonComparer_ShouldNotBeNull()
      => StandardFloatingPointComparers.DecimalFixedEpsilonComparer.Should().NotBeNull();

   #endregion

   #region DoubleFixedEpsilonComparer Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardFloatingPointComparers_DoubleFixedEpsilonComparer_ShouldNotBeNull()
      => StandardFloatingPointComparers.DoubleFixedEpsilonComparer.Should().NotBeNull();

   #endregion

   #region HalfFixedEpsilonComparer Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardFloatingPointComparers_HalfFixedEpsilonComparer_ShouldNotBeNull()
      => StandardFloatingPointComparers.HalfFixedEpsilonComparer.Should().NotBeNull();

   #endregion

   #region SingleFixedEpsilonComparer Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardFloatingPointComparers_SingleFixedEpsilonComparer_ShouldNotBeNull()
      => StandardFloatingPointComparers.SingleFixedEpsilonComparer.Should().NotBeNull();

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
