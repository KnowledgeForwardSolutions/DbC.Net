namespace DbC.Net.Tests.Unit.TestData;

public class Int128Data : ComparableValue<Int128>
{
   public Int128Data() : base(
      100,
      101,
      new ReverseComparer<Int128>(),
      Int128.MinValue,
      Int128.MaxValue)
   { }
}
