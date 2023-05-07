namespace DbC.Net.Tests.Unit.TestData;

public class UInt128Data : ComparableValue<UInt128>
{
   public UInt128Data() : base(
      100,
      101,
      Comparer<UInt128>.Default,
      new ReverseComparer<UInt128>(),
      UInt128.MinValue,
      UInt128.MaxValue,
      UInt128.MaxValue / 4,
      UInt128.MaxValue / 4 * 3,
      UInt128.MinValue,
      UInt128.MaxValue / 2,
      UInt128.MaxValue)
   { }
}