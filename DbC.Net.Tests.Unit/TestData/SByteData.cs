namespace DbC.Net.Tests.Unit.TestData;

public class SByteData : ComparableValue<SByte>
{
   public SByteData() : base(
      1,
      (SByte)(-1),
      Comparer<SByte>.Default,
      new ReverseComparer<SByte>(),
      SByte.MinValue,
      SByte.MaxValue,
      -64,
      64,
      SByte.MinValue,
      0,
      SByte.MaxValue)
   { }
}