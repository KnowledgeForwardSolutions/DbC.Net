namespace DbC.Net.Tests.Unit.TestData;

public class DoubleData : ComparableValue<Double>
{
   public DoubleData() : base(
      Double.Pi,
      Double.Tau,
      new ReverseComparer<Double>(),
      Double.MinValue,
      Double.MaxValue)
   { }
}
