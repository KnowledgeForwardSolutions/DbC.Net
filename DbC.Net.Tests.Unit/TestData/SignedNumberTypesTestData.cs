namespace DbC.Net.Tests.Unit.TestData;

public sealed class SignedNumberTypesTestData : IEnumerable<Object[]>
{
   public IEnumerator<Object[]> GetEnumerator()
   {
      yield return new Object[] { new BigIntegerData() };
      yield return new Object[] { new DecimalData() };
      yield return new Object[] { new DoubleData() };
      yield return new Object[] { new HalfData() };
      yield return new Object[] { new Int128Data() };
      yield return new Object[] { new Int16Data() };
      yield return new Object[] { new Int32Data() };
      yield return new Object[] { new Int64Data() };
      yield return new Object[] { new SByteData() };
      yield return new Object[] { new SingleData() };
      yield return new Object[] { new nintData() };
   }

   IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}