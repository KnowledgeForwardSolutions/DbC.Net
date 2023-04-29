namespace DbC.Net.Tests.Unit.TestData;

public sealed class EquatableTypesTestData : IEnumerable<Object[]>
{
   public IEnumerator<Object[]> GetEnumerator()
   {
      yield return new Object[] { new BigIntegerData() };
      yield return new Object[] { new BooleanData() };
      yield return new Object[] { new ByteData() };
      yield return new Object[] { new CharData() };
      yield return new Object[] { new DateOnlyData() };
      yield return new Object[] { new DateTimeData() };
      yield return new Object[] { new DateTimeOffsetData() };
      yield return new Object[] { new GuidData() };
      yield return new Object[] { new Int128Data() };
      yield return new Object[] { new Int16Data() };
      yield return new Object[] { new Int32Data() };
      yield return new Object[] { new Int64Data() };
      yield return new Object[] { new SByteData() };
      yield return new Object[] { new TimeOnlyData() };
      yield return new Object[] { new TimeSpanData() };
      yield return new Object[] { new UInt128Data() };
      yield return new Object[] { new UInt16Data() };
      yield return new Object[] { new UInt32Data() };
      yield return new Object[] { new UInt64Data() };
      yield return new Object[] { new nintData() };
      yield return new Object[] { new nuintData() };

      yield return new Object[] { new StringData() };

      yield return new Object[] { new PointStructData() };
      yield return new Object[] { new BoxRecordData() };
      yield return new Object[] { new ObservationClassData() };
   }

   IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
