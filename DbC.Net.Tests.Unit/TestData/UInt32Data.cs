namespace DbC.Net.Tests.Unit.TestData;

public class UInt32Data : ComparableValue<UInt32>
{
   public UInt32Data() : base(
      100,
      101,
      new ReverseComparer<UInt32>(),
      UInt32.MinValue,
      UInt32.MaxValue,
      UInt32.MaxValue / 4,
      UInt32.MaxValue / 4 * 3,
      UInt32.MinValue,
      UInt32.MaxValue / 2,
      UInt32.MaxValue)
   { }
}