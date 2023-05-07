namespace DbC.Net.Tests.Unit.TestData;

public class Int64Data : ComparableValue<Int64>
{
   public Int64Data() : base(
      100,
      101,
      Comparer<Int64>.Default,
      new ReverseComparer<Int64>(),
      Int64.MinValue,
      Int64.MaxValue,
      Int64.MinValue / 2,
      Int64.MaxValue / 2,
      Int64.MinValue,
      0,
      Int64.MaxValue)
   { }
}
