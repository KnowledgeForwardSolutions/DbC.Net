namespace DbC.Net.Tests.Unit.FloatingPoint;

#pragma warning disable xUnit1025 // InlineData should be unique within the Theory it belongs to
public class HalfRelativeEqualityComparerTests
{
   private readonly HalfRelativeErrorComparer _sut = new();

   [Theory]
   [InlineData(60000F, 60001F, 0.00001F, true)]
   [InlineData(60001F, 60000F, 0.00001F, true)]
   [InlineData(1000F, 1001F, 0.00001F, false)]
   [InlineData(1001F, 1000F, 0.00001F, false)]
   public void HalfRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForLargePositiveValues(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals((Half)x, (Half)y, (Half)tolerance).Should().Be(expected);

   [Theory]
   [InlineData(-60000F, -60001F, 0.00001F, true)]
   [InlineData(-60001F, -60000F, 0.00001F, true)]
   [InlineData(-1000F, -1001F, 0.00001F, false)]
   [InlineData(-1001F, -1000F, 0.00001F, false)]
   public void HalfRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForLargeNegativeValues(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals((Half)x, (Half)y, (Half)tolerance).Should().Be(expected);

   [Theory]
   [InlineData(1.0001F, 1.0002F, 0.00001F, true)]
   [InlineData(1.0002F, 1.0001F, 0.00001F, true)]
   [InlineData(1.002F, 1.001F, 0.00001F, false)]
   [InlineData(1.001F, 1.002F, 0.00001F, false)]
   public void HalfRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForValuesAroundOne(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals((Half)x, (Half)y, (Half)tolerance).Should().Be(expected);

   [Theory]
   [InlineData(-1.0001F, -1.0002F, 0.00001F, true)]
   [InlineData(-1.0002F, -1.0001F, 0.00001F, true)]
   [InlineData(-1.002F, -1.001F, 0.00001F, false)]
   [InlineData(-1.001F, -1.002F, 0.00001F, false)]
   public void HalfRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForValuesAroundNegativeOne(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals((Half)x, (Half)y, (Half)tolerance).Should().Be(expected);

   [Theory]
   [InlineData(0.001000001F, 0.001000002F, 0.00001F, true)]
   [InlineData(0.001000002F, 0.001000001F, 0.00001F, true)]
   [InlineData(0.000102F, 0.000101F, 0.00001F, false)]
   [InlineData(0.000101F, 0.000102F, 0.00001F, false)]
   public void HalfRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForValuesBetweenOneAndZero(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals((Half)x, (Half)y, (Half)tolerance).Should().Be(expected);

   [Theory]
   [InlineData(-0.001000001F, -0.001000002F, 0.00001F, true)]
   [InlineData(-0.001000002F, -0.001000001F, 0.00001F, true)]
   [InlineData(-0.0001002F, -0.001001F, 0.00001F, false)]
   [InlineData(-0.0001001F, -0.001002F, 0.00001F, false)]
   public void HalfRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForValuesBetweenNegativeOneAndZero(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals((Half)x, (Half)y, (Half)tolerance).Should().Be(expected);

   [Theory]
   [InlineData(0.3F, 0.30000003F, 0.00001F, true)]
   [InlineData(-0.3F, -0.30000003F, 0.00001F, true)]
   public void HalfRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_WhenSmallDifferenceFromZero(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals((Half)x, (Half)y, (Half)tolerance).Should().Be(expected);

   [Theory]
   [InlineData(0F, 0F, 0.00001F, true)]
   [InlineData(0F, -0F, 0.00001F, true)]
   [InlineData(-0F, 0F, 0.00001F, true)]
   [InlineData(0.0000001F, 0F, 0.00001F, false)]
   [InlineData(0F, 0.0000001F, 0.00001F, false)]
   [InlineData(-0.0000001F, -0F, 0.00001F, false)]
   [InlineData(-0F, -0.0000001F, 0.00001F, false)]

   [InlineData(0F, 1E-7F, 0.01F, true)]
   [InlineData(1e-7F, 0F, 0.01F, true)]
   [InlineData(-1e-7F, 0F, 0.00000001F, false)]
   [InlineData(0F, -1e-7F, 0.00000001F, false)]
   public void HalfRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_WhenComparingToZero(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals((Half)x, (Half)y, (Half)tolerance).Should().Be(expected);

   public static TheoryData<Half, Half, Single, Boolean> ExtremeValuesTestData => new()
   {
      { Half.MaxValue, Half.MaxValue, 0.00001F, true },
      { Half.MaxValue, -Half.MaxValue, 0.00001F, false },
      { -Half.MaxValue, Half.MaxValue, 0.00001F, false },
      { Half.MaxValue, Half.MaxValue / (Half)2, 0.00001F, false },
      { Half.MaxValue, -Half.MaxValue / (Half) 2, 0.00001F, false },
      { -Half.MaxValue, Half.MaxValue / (Half) 2, 0.00001F, false },
   };

   [Theory]
   [MemberData(nameof(ExtremeValuesTestData))]
   public void HalfRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForExtremeValues(
      Half x,
      Half y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, (Half)tolerance).Should().Be(expected);

   public static TheoryData<Half, Half, Half, Boolean> InfinityTestData => new()
   {
      { Half.PositiveInfinity, Half.PositiveInfinity, (Half)0.00001F, true },
      { Half.NegativeInfinity, Half.NegativeInfinity, (Half)0.00001F, true },
      { Half.NegativeInfinity, Half.PositiveInfinity, (Half)0.00001F, false },
      { Half.PositiveInfinity, Half.MaxValue, (Half)0.00001F, false },
      { Half.NegativeInfinity, Half.MinValue, (Half)0.00001F, false },
   };

   [Theory]
   [MemberData(nameof(InfinityTestData))]
   public void HalfRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForInfinity(
      Half x,
      Half y,
      Half tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals(x, y, tolerance).Should().Be(expected);

   public static TheoryData<Half, Half, Single, Boolean> NaNTestData => new()
   {
      { Half.NaN, Half.NaN, 0.00001F, false },
      { Half.NaN, (Half)0F, 0.00001F, false },
      { Half.NaN, (Half)(-0F), 0.00001F, false },
      { (Half)(-0F), Half.NaN, 0.00001F, false },
      { (Half)0F, Half.NaN, 0.00001F, false },
      { Half.NaN, Half.PositiveInfinity, 0.00001F, false },
      { Half.PositiveInfinity, Half.NaN, 0.00001F, false },
      { Half.NaN, Half.NegativeInfinity, 0.00001F, false },
      { Half.NegativeInfinity, Half.NaN, 0.00001F, false },
      { Half.NaN, Half.MaxValue, 0.00001F, false },
      { Half.MaxValue, Half.NaN, 0.00001F, false },
      { Half.NaN, -Half.MaxValue, 0.00001F, false },
      { -Half.MaxValue, Half.NaN, 0.00001F, false },
      { Half.NaN, Half.MinValue, 0.00001F, false },
      { Half.MinValue, Half.NaN, 0.00001F, false },
      { Half.NaN, -Half.MinValue, 0.00001F, false },
      { -Half.MinValue, Half.NaN, 0.00001F, false },
   };

   [Theory]
   [MemberData(nameof(NaNTestData))]
   public void HalfRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForNaN(
      Half x,
      Half y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals((Half)x, (Half)y, (Half)tolerance).Should().Be(expected);

   [Theory]
   [InlineData(Single.Epsilon, -Single.Epsilon, 0.00001F, true)]
   [InlineData(1.000000001F, -1F, 0.00001F, false)]
   [InlineData(-1F, 1.000000001F, 0.00001F, false)]
   [InlineData(-1.000000001F, 1F, 0.00001F, false)]
   [InlineData(1F, -1.000000001F, 0.00001F, false)]
   [InlineData(10 * Single.MinValue, 10 * -Single.MinValue, 0.00001F, false)]
   [InlineData(10000 * Single.MinValue, 10000 * -Single.MinValue, 0.00001F, false)]
   public void HalfRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForOppositeSidesOfZero(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals((Half)x, (Half)y, (Half)tolerance).Should().Be(expected);

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
   public void HalfRelativeErrorComparer_ApproximatelyEquals_ShouldReturnExpectedResult_ForNumbersVeryCloseToZero(
      Single x,
      Single y,
      Single tolerance,
      Boolean expected)
      => _sut.ApproximatelyEquals((Half)x, (Half)y, (Half)tolerance).Should().Be(expected);
}
