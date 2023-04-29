namespace DbC.Net.Tests.Unit.TestData;

public class DoubleData : FloatingPointValue<Double>
{
   public DoubleData() : base(
      3.141592653589793D,
      0.000000000000001D,
      0.000000000000005D,
      0.000000000000003D,
      StandardFloatingPointComparers.DoubleFixedErrorComparer,
      0.0000000000000002D,
      StandardFloatingPointComparers.DoubleRelativeErrorComparer,
      Double.MaxValue,
      Double.MinValue,
      Comparer<Double>.Default,
      new ReverseComparer<Double>(),
      Double.MinValue / 2,
      Double.MaxValue / 2,
      Double.MaxValue,
      0,
      Double.MinValue)
   { }
}
