namespace DbC.Net.Tests.Unit.TestData;

public class ReferenceTypesTestData : IEnumerable<Object[]>
{
   public IEnumerator<Object[]> GetEnumerator()
   {
      yield return new Object[] { new StringData() };

      yield return new Object[] { new PointClassData() };
      yield return new Object[] { new PointRecordData() };
   }

   IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
