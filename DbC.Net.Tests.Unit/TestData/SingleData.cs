namespace DbC.Net.Tests.Unit.TestData;

public class SingleData : FloatingPointValue<Single>
{
   public SingleData() : base(
      3.14152F,
      0.00001F,
      0.00005F,
      0.00003F,
      StandardFloatingPointComparers.SingleFixedErrorComparer,
      0.000002F,
      StandardFloatingPointComparers.SingleRelativeErrorComparer,
      Single.MaxValue,
      Single.MinValue)
   { }
}