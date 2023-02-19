namespace DbC.Net.Tests.Unit.TestData;

public class SByteData : ComparableValue<SByte>
{
   public SByteData() : base(
      1,
      (SByte)(-1),
      new ReverseComparer<SByte>(),
      SByte.MinValue,
      SByte.MaxValue)
   { }
}