namespace DbC.Net.Tests.Unit.TestData;

public class UInt32Data : ComparableValue<UInt32>
{
   public UInt32Data() : base(
      100,
      101,
      new ReverseComparer<UInt32>(),
      UInt32.MinValue,
      UInt32.MaxValue)
   { }
}