namespace DbC.Net.Tests.Unit.TestData;

public class Int64Data : ComparableValue<Int64>
{
   public Int64Data() : base(
      100,
      101,
      new ReverseComparer<Int64>(),
      Int64.MinValue,
      Int64.MaxValue)
   { }
}
