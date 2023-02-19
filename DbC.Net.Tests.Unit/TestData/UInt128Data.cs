namespace DbC.Net.Tests.Unit.TestData;

public class UInt128Data : ComparableValue<UInt128>
{
   public UInt128Data() : base(
      100,
      101,
      new ReverseComparer<UInt128>(),
      UInt128.MinValue,
      UInt128.MaxValue)
   { }
}