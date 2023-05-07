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
      StandardFloatingPointComparers.HalfRelativeErrorComparer,
      Half.MaxValue,
      Half.MinValue,
      Comparer<Half>.Default,
      new ReverseComparer<Half>(),
      Half.MinValue / (Half)2,
      Half.MaxValue / (Half)2,
      Half.MaxValue,
      (Half)0,
      Half.MinValue)
   { }
}

