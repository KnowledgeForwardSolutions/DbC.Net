namespace DbC.Net.Tests.Unit.TestData;

public class UnsignedNumberTypesTestData : IEnumerable<Object[]>
{
   public IEnumerator<Object[]> GetEnumerator()
   {
      yield return new Object[] { new ByteData() };
      yield return new Object[] { new CharData() };
      yield return new Object[] { new UInt128Data() };
      yield return new Object[] { new UInt16Data() };
      yield return new Object[] { new UInt32Data() };
      yield return new Object[] { new UInt64Data() };
      yield return new Object[] { new nuintData() };
   }

   IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}