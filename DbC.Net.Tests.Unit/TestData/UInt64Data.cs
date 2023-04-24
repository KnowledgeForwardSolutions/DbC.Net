namespace DbC.Net.Tests.Unit.TestData;

public class UInt64Data : ComparableValue<UInt64>
{
   public UInt64Data() : base(
      100,
      101,
      new ReverseComparer<UInt64>(),
      UInt64.MinValue,
      UInt64.MaxValue,
      UInt64.MaxValue / 4,
      UInt64.MaxValue / 4 * 3,
      UInt64.MinValue,
      UInt64.MaxValue / 2,
      UInt64.MaxValue)
   { }
}