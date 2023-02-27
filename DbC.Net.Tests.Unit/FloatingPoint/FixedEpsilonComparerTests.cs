using Xunit.Abstractions;

namespace DbC.Net.Tests.Unit.FloatingPoint;

public class FixedEpsilonComparerTests
{
   private readonly ITestOutputHelper _console;

   public FixedEpsilonComparerTests(ITestOutputHelper console) => _console = console;

   public static IEnumerable<Object[]> LessThanEpsilonData => new List<Object[]>
   {
      new Object[] { (Half)3.14F, (Half)3.16F, (Half)0.03F },
      new Object[] { 3.14152F, 3.14156F, 0.0001F },
      new Object[] { 3.141592653589793D, 3.141592653589791D, 0.000000000001D },
      new Object[] { 3.141592M, 3.141594M, 0.00001M },
   };

   [Theory]
   [MemberData(nameof(LessThanEpsilonData))]
   public void FixedEpsilonComparer_ApproximatelyEquals_ShouldReturnTrue_WhenDeltaIsLessThanEpsilon<T>(T x, T y, T epsilon) where T: IFloatingPoint<T>
   {
      _console.WriteLine($"x: {x}, y: {y}, epsilon: {epsilon}");

      // Arrange.
      var sut = new FixedEpsilonComparer<T>();

      // Act/assert.
      sut.ApproximatelyEquals(x, y, epsilon).Should().BeTrue();
   }

   public static IEnumerable<Object[]> GreaterThanEpsilonData => new List<Object[]>
   {
      new Object[] { (Half)6.28F, (Half)6.24F, (Half)0.02F },
      new Object[] { 6.28318F, 6.28313F, 0.00001F },
      new Object[] { 6.283185307179586D, 6.283185307179581D, 0.000000000000001D },
      new Object[] { 6.283185M, 6.283189M, 0.000001M },
   };

   [Theory]
   [MemberData(nameof(GreaterThanEpsilonData))]
   public void FixedEpsilonComparer_ApproximatelyEquals_ShouldReturnFalse_WhenDeltaIsGreaterThanEpsilon<T>(T x, T y, T epsilon) where T : IFloatingPoint<T>
   {
      _console.WriteLine($"x: {x}, y: {y}, epsilon: {epsilon}");

      // Arrange.
      var sut = new FixedEpsilonComparer<T>();

      // Act/assert.
      sut.ApproximatelyEquals(x, y, epsilon).Should().BeFalse();
   }
}
