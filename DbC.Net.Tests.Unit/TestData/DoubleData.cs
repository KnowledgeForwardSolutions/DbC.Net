namespace DbC.Net.Tests.Unit.TestData;

public class DoubleData : FloatingPointValue<Double>
{
   public DoubleData() : base(
      3.141592653589793D,
      0.000000000000001D,
      0.000000000000005D,
      0.000000000000003D,
      StandardFloatingPointComparers.DoubleFixedEpsilonComparer,
      0.0000000000000002D,
      StandardFloatingPointComparers.DoubleRelativeErrorComparer)
   { }
}
