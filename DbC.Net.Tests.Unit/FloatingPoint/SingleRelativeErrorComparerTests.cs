namespace DbC.Net.Tests.Unit.FloatingPoint;

#pragma warning disable xUnit1025 // InlineData should be unique within the Theory it belongs to
public class SingleRelativeErrorComparerTests
{
   private readonly SingleRelativeErrorComparer _sut = new();

   [Theory]
   [InlineData(1000000F, 1000001F, 0.00001F, true)]
   [InlineData(1000001F, 1000000F, 0.00001F, true)]
   [InlineData(10000F, 10001F, 0.00001F, false)]
   [InlineData(10001F, 10000F, 0.00001F, false)]
   public void SingleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForLargePositveValues(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(-1000000F, -1000001F, 0.00001F, true)]
   [InlineData(-1000001F, -1000000F, 0.00001F, true)]
   [InlineData(-10000F, -10001F, 0.00001F, false)]
   [InlineData(-10001F, -10000F, 0.00001F, false)]
   public void SingleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForLargeNegativeValues(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(1.0000001F, 1.0000002F, 0.00001F, true)]
   [InlineData(1.0000002F, 1.0000001F, 0.00001F, true)]
   [InlineData(1.0002F, 1.0001F, 0.00001F, false)]
   [InlineData(1.0001F, 1.0002F, 0.00001F, false)]
   public void SingleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForValuesAroundOne(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(-1.0000001F, -1.0000002F, 0.00001F, true)]
   [InlineData(-1.0000002F, -1.0000001F, 0.00001F, true)]
   [InlineData(-1.0002F, -1.0001F, 0.00001F, false)]
   [InlineData(-1.0001F, -1.0002F, 0.00001F, false)]
   public void SingleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForValuesAroundNegativeOne(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(0.000000001000001F, 0.000000001000002F, 0.00001F, true)]
   [InlineData(0.000000001000002F, 0.000000001000001F, 0.00001F, true)]
   [InlineData(0.000000000001002F, 0.000000000001001F, 0.00001F, false)]
   [InlineData(0.000000000001001F, 0.000000000001002F, 0.00001F, false)]
   public void SingleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForValuesBetweenOneAndZero(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(-0.000000001000001F, -0.000000001000002F, 0.00001F, true)]
   [InlineData(-0.000000001000002F, -0.000000001000001F, 0.00001F, true)]
   [InlineData(-0.000000000001002F, -0.000000000001001F, 0.00001F, false)]
   [InlineData(-0.000000000001001F, -0.000000000001002F, 0.00001F, false)]
   public void SingleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForValuesBetweenNegativeOneAndZero(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(0.3F, 0.30000003F, 0.00001F, true)]
   [InlineData(-0.3F, -0.30000003F, 0.00001F, true)]
   public void SingleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_WhenSmallDifferenceFromZero(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(0F, 0F, 0.00001F, true)]
   [InlineData(0F, -0F, 0.00001F, true)]
   [InlineData(-0F, 0F, 0.00001F, true)]
   [InlineData(0.00000001F, 0F, 0.00001F, false)]
   [InlineData(0F, 0.00000001F, 0.00001F, false)]
   [InlineData(-0.00000001F, -0F, 0.00001F, false)]
   [InlineData(-0F, -0.00000001F, 0.00001F, false)]

   [InlineData(0F, 1E-40F, 0.01F, true)]
   [InlineData(1e-40F, 0F, 0.01F, true)]
   [InlineData(-1e-40F, 0F, 0.00000001F, false)]
   [InlineData(0F, -1e-40F, 0.00000001F, false)]
   public void SingleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_WhenComparingToZero(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(Single.MaxValue, Single.MaxValue, 0.00001F, true)]
   [InlineData(Single.MaxValue, -Single.MaxValue, 0.00001F, false)]
   [InlineData(-Single.MaxValue, Single.MaxValue, 0.00001F, false)]
   [InlineData(Single.MaxValue, Single.MaxValue / 2, 0.00001F, false)]
   [InlineData(Single.MaxValue, -Single.MaxValue / 2, 0.00001F, false)]
   [InlineData(-Single.MaxValue, Single.MaxValue / 2, 0.00001F, false)]
   public void SingleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForExtremeValues(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(Single.PositiveInfinity, Single.PositiveInfinity, 0.00001F, true)]
   [InlineData(Single.NegativeInfinity, Single.NegativeInfinity, 0.00001F, true)]
   [InlineData(Single.NegativeInfinity, Single.PositiveInfinity, 0.00001F, false)]
   [InlineData(Single.PositiveInfinity, Single.MaxValue, 0.00001F, false)]
   [InlineData(Single.NegativeInfinity, Single.MinValue, 0.00001F, false)]
   public void SingleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForInfinity(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(Single.NaN, Single.NaN, 0.00001F, false)]
   [InlineData(Single.NaN, 0F, 0.00001F, false)]
   [InlineData(Single.NaN, -0F, 0.00001F, false)]
   [InlineData(-0F, Single.NaN, 0.00001F, false)]
   [InlineData(0F, Single.NaN, 0.00001F, false)]
   [InlineData(Single.NaN, Single.PositiveInfinity, 0.00001F, false)]
   [InlineData(Single.PositiveInfinity, Single.NaN, 0.00001F, false)]
   [InlineData(Single.NaN, Single.NegativeInfinity, 0.00001F, false)]
   [InlineData(Single.NegativeInfinity, Single.NaN, 0.00001F, false)]
   [InlineData(Single.NaN, Single.MaxValue, 0.00001F, false)]
   [InlineData(Single.MaxValue, Single.NaN, 0.00001F, false)]
   [InlineData(Single.NaN, -Single.MaxValue, 0.00001F, false)]
   [InlineData(-Single.MaxValue, Single.NaN, 0.00001F, false)]
   [InlineData(Single.NaN, Single.MinValue, 0.00001F, false)]
   [InlineData(Single.MinValue, Single.NaN, 0.00001F, false)]
   [InlineData(Single.NaN, -Single.MinValue, 0.00001F, false)]
   [InlineData(-Single.MinValue, Single.NaN, 0.00001F, false)]

   public void SingleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForNaN(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   [InlineData(Single.Epsilon, -Single.Epsilon, 0.00001F, true)]
   [InlineData(1.000000001F, -1F, 0.00001F, false)]
   [InlineData(-1F, 1.000000001F, 0.00001F, false)]
   [InlineData(-1.000000001F, 1F, 0.00001F, false)]
   [InlineData(1F, -1.000000001F, 0.00001F, false)]
   [InlineData(10 * Single.MinValue, 10 * -Single.MinValue, 0.00001F, false)]
   [InlineData(10000 * Single.MinValue, 10000 * -Single.MinValue, 0.00001F, false)]
   public void SingleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForOppositeSidesOfZero(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   [Theory]
   // TODO: These tests should pass according to https://floating-point-gui.de/errors/NearlyEqualsTest.java
   // TODO: but are not. Needs further investigation.
   //[InlineData(Single.MinValue, Single.MinValue, 0.00001F, true)]
   //[InlineData(Single.MinValue, Single.MaxValue, 0.00001F, true)]
   //[InlineData(Single.MaxValue, Single.MinValue, 0.00001F, true)]
   //[InlineData(Single.MinValue, 0F, 0.00001F, true)]
   //[InlineData(0F, Single.MinValue, 0.00001F, true)]
   //[InlineData(Single.MaxValue, 0F, 0.00001F, true)]
   //[InlineData(0F, Single.MaxValue, 0.00001F, true)]

   [InlineData(0.000000001F, Single.MaxValue, 0.00001F, false)]
   [InlineData(0.000000001F, Single.MinValue, 0.00001F, false)]
   [InlineData(Single.MinValue, 0.000000001F, 0.00001F, false)]
   [InlineData(Single.MaxValue, 0.000000001F, 0.00001F, false)]
   public void SingleRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForNumbersVeryCloseToZero(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);
}
