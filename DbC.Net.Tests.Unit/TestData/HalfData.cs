namespace DbC.Net.Tests.Unit.TestData;

public class HalfData : FloatingPointValue<Half>
{
   public HalfData() : base(
      (Half)3.14F,
      (Half)0.01F,
      (Half)0.05F,
      (Half)0.03F,
      StandardFloatingPointComparers.HalfFixedErrorComparer,
      (Half)0.002F,
      StandardFloatingPointComparers.HalfRelativeErrorComparer)
   { }
}

