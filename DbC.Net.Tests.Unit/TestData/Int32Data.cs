namespace DbC.Net.Tests.Unit.TestData;

public class Int32Data : ComparableValue<Int32>
{
   public Int32Data() : base(
      100,
      101,
      Comparer<Int32>.Default,
      new ReverseComparer<Int32>(),
      Int32.MinValue,
      Int32.MaxValue,
      Int32.MinValue / 2,
      Int32.MaxValue / 2,
      Int32.MinValue,
      0,
      Int32.MaxValue)
   { }
}