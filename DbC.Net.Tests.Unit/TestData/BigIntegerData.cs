namespace DbC.Net.Tests.Unit.TestData;

public class BigIntegerData : ComparableValue<BigInteger>
{
   public BigIntegerData() : base(
      100,
      -100,
      new ReverseComparer<BigInteger>(),
      BigInteger.Multiply(Int64.MinValue, 2),
      BigInteger.Multiply(Int64.MaxValue, 2),
      Int64.MinValue,
      Int64.MaxValue,
      BigInteger.Multiply(Int64.MinValue, 2),
      0,
      BigInteger.Multiply(Int64.MaxValue, 2))
   { }
}
