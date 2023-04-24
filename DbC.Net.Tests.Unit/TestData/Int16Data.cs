namespace DbC.Net.Tests.Unit.TestData;

public class Int16Data : ComparableValue<Int16>
{
   public Int16Data() : base(
      1,
      -1,
      new ReverseComparer<Int16>(),
      Int16.MinValue,
      Int16.MaxValue,
      Int16.MinValue / 2,
      Int16.MaxValue / 2,
      Int16.MinValue,
      0,
      Int16.MaxValue)
   { }
}