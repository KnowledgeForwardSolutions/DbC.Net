namespace DbC.Net.Tests.Unit.TestData;

public class NumberTypesTestData : IEnumerable<Object[]>
{
   public IEnumerator<Object[]> GetEnumerator()
   {
      yield return new Object[] { new BigIntegerData() };
      yield return new Object[] { new ByteData() };
      yield return new Object[] { new CharData() };
      yield return new Object[] { new DecimalData() };
      yield return new Object[] { new DoubleData() };
      yield return new Object[] { new HalfData() };
      yield return new Object[] { new Int128Data() };
      yield return new Object[] { new Int16Data() };
      yield return new Object[] { new Int32Data() };
      yield return new Object[] { new Int64Data() };
      yield return new Object[] { new SByteData() };
      yield return new Object[] { new SingleData() };
      yield return new Object[] { new UInt128Data() };
      yield return new Object[] { new UInt16Data() };
      yield return new Object[] { new UInt32Data() };
      yield return new Object[] { new UInt64Data() };
      yield return new Object[] { new nintData() };
      yield return new Object[] { new nuintData() };
   }

   IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}