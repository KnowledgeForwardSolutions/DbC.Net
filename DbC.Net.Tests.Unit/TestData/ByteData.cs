namespace DbC.Net.Tests.Unit.TestData;

public class ByteData : ComparableValue<Byte>
{
   public ByteData() : base(
      100,
      101,
      Comparer<Byte>.Default,
      new ReverseComparer<Byte>(),
      Byte.MinValue,
      Byte.MaxValue,
      10,
      100,
      5,
      45,
      105)
   { }
}