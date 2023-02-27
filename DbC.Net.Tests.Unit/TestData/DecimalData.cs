namespace DbC.Net.Tests.Unit.TestData;

public class DecimalData : FloatingPointValue<Decimal>
{
   public DecimalData() : base(
      3.141592M,
      0.000001M,
      0.000005M,
      0.000003M,
      StandardFloatingPointComparers.DecimalFixedEpsilonComparer,
      0.000003M,
      default!)
   { }
}
