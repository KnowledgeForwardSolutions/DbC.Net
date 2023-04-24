namespace DbC.Net.Tests.Unit.TestData;

public class DecimalData : FloatingPointValue<Decimal>
{
   public DecimalData() : base(
      3.141592M,
      0.000001M,
      0.000005M,
      0.000003M,
      StandardFloatingPointComparers.DecimalFixedErrorComparer,
      0.000003M,
      default!,
      Decimal.MaxValue,
      Decimal.MinValue,
      new ReverseComparer<Decimal>(),
      Decimal.MinValue / 2,
      Decimal.MaxValue / 2,
      Decimal.MaxValue,
      0,
      Decimal.MinValue)
   { }
}
