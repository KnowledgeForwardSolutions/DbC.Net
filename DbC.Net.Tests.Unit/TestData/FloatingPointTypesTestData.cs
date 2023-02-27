namespace DbC.Net.Tests.Unit.TestData;

public class FloatingPointTypesTestData : IEnumerable<Object[]>
{
   public IEnumerator<Object[]> GetEnumerator()
   {
      yield return new Object[] { new DecimalData() };
      yield return new Object[] { new DoubleData() };
      yield return new Object[] { new HalfData() };
      yield return new Object[] { new SingleData() };
   }

   IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}