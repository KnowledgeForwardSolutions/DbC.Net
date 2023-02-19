namespace DbC.Net.Tests.Unit.TestData;

public class Int32Data : ComparableValue<Int32>
{
   public Int32Data() : base(
      100,
      101,
      new ReverseComparer<Int32>(),
      Int32.MinValue,
      Int32.MaxValue)
   { }
}