namespace DbC.Net.Tests.Unit.TestData;

public class UInt16Data : ComparableValue<UInt16>
{
   public UInt16Data() : base(
      100,
      101,
      new ReverseComparer<UInt16>(),
      UInt16.MinValue,
      UInt16.MaxValue)
   { }
}