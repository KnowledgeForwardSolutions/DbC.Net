namespace DbC.Net.Tests.Unit.FloatingPoint;

#pragma warning disable xUnit1025 // InlineData should be unique within the Theory it belongs to
public class DoubleRelativeErrorComparerTests
{
   private readonly DoubleRelativeErrorComparer _sut = new();

   [Theory]
   [InlineData(1000000D, 1000001D, 0.00001D, true)]
   [InlineData(1000001D, 1000000D, 0.00001D, true)]
   [InlineData(10000D, 10001D, 0.00001D, false)]
   [InlineData(10001D, 10000D, 0.00001D, false)]
   public void DoubleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForLargePositveValues(
      Double x,
      Double y,
      Double tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(-1000000D, -1000001D, 0.00001D, true)]
   [InlineData(-1000001D, -1000000D, 0.00001D, true)]
   [InlineData(-10000D, -10001D, 0.00001D, false)]
   [InlineData(-10001D, -10000D, 0.00001D, false)]
   public void DoubleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForLargeNegativeValues(
      Double x,
      Double y,
      Double tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(1.0000001D, 1.0000002D, 0.00001D, true)]
   [InlineData(1.0000002D, 1.0000001D, 0.00001D, true)]
   [InlineData(1.0002D, 1.0001D, 0.00001D, false)]
   [InlineData(1.0001D, 1.0002D, 0.00001D, false)]
   public void DoubleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForValuesAroundOne(
      Double x,
      Double y,
      Double tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(-1.0000001D, -1.0000002D, 0.00001D, true)]
   [InlineData(-1.0000002D, -1.0000001D, 0.00001D, true)]
   [InlineData(-1.0002D, -1.0001D, 0.00001D, false)]
   [InlineData(-1.0001D, -1.0002D, 0.00001D, false)]
   public void DoubleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForValuesAroundNegativeOne(
      Double x,
      Double y,
      Double tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(0.000000001000001D, 0.000000001000002D, 0.00001D, true)]
   [InlineData(0.000000001000002D, 0.000000001000001D, 0.00001D, true)]
   [InlineData(0.000000000001002D, 0.000000000001001D, 0.00001D, false)]
   [InlineData(0.000000000001001D, 0.000000000001002D, 0.00001D, false)]
   public void DoubleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForValuesBetweenOneAndZero(
      Double x,
      Double y,
      Double tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(-0.000000001000001D, -0.000000001000002D, 0.00001D, true)]
   [InlineData(-0.000000001000002D, -0.000000001000001D, 0.00001D, true)]
   [InlineData(-0.000000000001002D, -0.000000000001001D, 0.00001D, false)]
   [InlineData(-0.000000000001001D, -0.000000000001002D, 0.00001D, false)]
   public void DoubleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForValuesBetweenNegativeOneAndZero(
      Double x,
      Double y,
      Double tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(0.3D, 0.30000003D, 0.00001D, true)]
   [InlineData(-0.3D, -0.30000003D, 0.00001D, true)]
   public void DoubleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_WhenSmallDifferenceFromZero(
      Double x,
      Double y,
      Double tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(0D, 0D, 0.00001D, true)]
   [InlineData(0D, -0D, 0.00001D, true)]
   [InlineData(-0D, 0D, 0.00001D, true)]
   [InlineData(0.00000001D, 0D, 0.00001D, false)]
   [InlineData(0D, 0.00000001D, 0.00001D, false)]
   [InlineData(-0.00000001D, -0D, 0.00001D, false)]
   [InlineData(-0D, -0.00000001D, 0.00001D, false)]

   [InlineData(0D, 1E-310D, 0.01D, true)]
   [InlineData(1e-310D, 0D, 0.01D, true)]
   [InlineData(-1e-310D, 0D, 0.00000001D, false)]
   [InlineData(0D, -1e-310D, 0.00000001D, false)]
   public void DoubleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_WhenComparingToZero(
      Double x,
      Double y,
      Double tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(Double.MaxValue, Double.MaxValue, 0.00001D, true)]
   [InlineData(Double.MaxValue, -Double.MaxValue, 0.00001D, false)]
   [InlineData(-Double.MaxValue, Double.MaxValue, 0.00001D, false)]
   [InlineData(Double.MaxValue, Double.MaxValue / 2, 0.00001D, false)]
   [InlineData(Double.MaxValue, -Double.MaxValue / 2, 0.00001D, false)]
   [InlineData(-Double.MaxValue, Double.MaxValue / 2, 0.00001D, false)]
   public void DoubleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForExtremeValues(
      Double x,
      Double y,
      Double tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(Double.PositiveInfinity, Double.PositiveInfinity, 0.00001D, true)]
   [InlineData(Double.NegativeInfinity, Double.NegativeInfinity, 0.00001D, true)]
   [InlineData(Double.NegativeInfinity, Double.PositiveInfinity, 0.00001D, false)]
   [InlineData(Double.PositiveInfinity, Double.MaxValue, 0.00001D, false)]
   [InlineData(Double.NegativeInfinity, Double.MinValue, 0.00001D, false)]
   public void DoubleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForInfinity(
      Double x,
      Double y,
      Double tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(Double.NaN, Double.NaN, 0.00001D, false)]
   [InlineData(Double.NaN, 0D, 0.00001D, false)]
   [InlineData(Double.NaN, -0D, 0.00001D, false)]
   [InlineData(-0D, Double.NaN, 0.00001D, false)]
   [InlineData(0D, Double.NaN, 0.00001D, false)]
   [InlineData(Double.NaN, Double.PositiveInfinity, 0.00001D, false)]
   [InlineData(Double.PositiveInfinity, Double.NaN, 0.00001D, false)]
   [InlineData(Double.NaN, Double.NegativeInfinity, 0.00001D, false)]
   [InlineData(Double.NegativeInfinity, Double.NaN, 0.00001D, false)]
   [InlineData(Double.NaN, Double.MaxValue, 0.00001D, false)]
   [InlineData(Double.MaxValue, Double.NaN, 0.00001D, false)]
   [InlineData(Double.NaN, -Double.MaxValue, 0.00001D, false)]
   [InlineData(-Double.MaxValue, Double.NaN, 0.00001D, false)]
   [InlineData(Double.NaN, Double.MinValue, 0.00001D, false)]
   [InlineData(Double.MinValue, Double.NaN, 0.00001D, false)]
   [InlineData(Double.NaN, -Double.MinValue, 0.00001D, false)]
   [InlineData(-Double.MinValue, Double.NaN, 0.00001D, false)]

   public void DoubleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForNaN(
      Double x,
      Double y,
      Double tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(Double.Epsilon, -Double.Epsilon, 0.00001D, true)]
   [InlineData(1.000000001D, -1D, 0.00001D, false)]
   [InlineData(-1D, 1.000000001D, 0.00001D, false)]
   [InlineData(-1.000000001D, 1D, 0.00001D, false)]
   [InlineData(1D, -1.000000001D, 0.00001D, false)]
   [InlineData(10 * Double.MinValue, 10 * -Double.MinValue, 0.00001D, false)]
   [InlineData(10000 * Double.MinValue, 10000 * -Double.MinValue, 0.00001D, false)]
   public void DoubleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForOppositeSidesOfZero(
      Double x,
      Double y,
      Double tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   // TODO: These tests should pass according to https://floating-point-gui.de/errors/NearlyEqualsTest.java
   // TODO: but are not. Needs further investigation.
   //[InlineData(Double.MinValue, Double.MinValue, 0.00001D, true)]
   //[InlineData(Double.MinValue, Double.MaxValue, 0.00001D, true)]
   //[InlineData(Double.MaxValue, Double.MinValue, 0.00001D, true)]
   //[InlineData(Double.MinValue, 0D, 0.00001D, true)]
   //[InlineData(0D, Double.MinValue, 0.00001D, true)]
   //[InlineData(Double.MaxValue, 0D, 0.00001D, true)]
   //[InlineData(0D, Double.MaxValue, 0.00001D, true)]

   [InlineData(0.000000001D, Double.MaxValue, 0.00001D, false)]
   [InlineData(0.000000001D, Double.MinValue, 0.00001D, false)]
   [InlineData(Double.MinValue, 0.000000001D, 0.00001D, false)]
   [InlineData(Double.MaxValue, 0.000000001D, 0.00001D, false)]
   public void DoubleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForNumbersVeryCloseToZero(
      Double x,
      Double y,
      Double tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);
}
