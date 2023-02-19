namespace DbC.Net.Tests.Unit.TestData;

public class DecimalData : ComparableValue<Decimal>
{
   public DecimalData() : base(
      3.141592653589793238M,
      0.0000000000000000001M,
      new ReverseComparer<Decimal>(),
      Decimal.MinValue,
      Decimal.MaxValue)
   { }
}
