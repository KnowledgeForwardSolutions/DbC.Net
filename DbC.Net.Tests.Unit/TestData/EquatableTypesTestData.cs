namespace DbC.Net.Tests.Unit.TestData;

public class EquatableTypesTestData : IEnumerable<Object[]>
{
   public IEnumerator<Object[]> GetEnumerator()
   {
      yield return new Object[] { new BigIntegerData() };
      yield return new Object[] { new BooleanData() };
      yield return new Object[] { new ByteData() };
      yield return new Object[] { new CharData() };
      yield return new Object[] { new DateOnlyData() };

      yield return new Object[] { new StringData() };

      yield return new Object[] { new PointClassData() };
      yield return new Object[] { new PointRecordData() };
      yield return new Object[] { new PointStructData() };
   }

   IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
