namespace DbC.Net.Tests.Unit.TestData;

public class ByteData : ComparableValue<Byte>
{
   public ByteData() : base(
      100,
      101,
      new ReverseComparer<Byte>(),
      Byte.MinValue,
      Byte.MaxValue)
   { }
}