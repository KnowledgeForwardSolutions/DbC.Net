namespace DbC.Net.Tests.Unit.TestData;

public class ReferenceTypesTestData : IEnumerable<Object[]>
{
   public IEnumerator<Object[]> GetEnumerator()
   {
      yield return new Object[] { new StringData() };

      yield return new Object[] { new ObservationClassData() };
      yield return new Object[] { new BoxRecordData() };
   }

   IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
