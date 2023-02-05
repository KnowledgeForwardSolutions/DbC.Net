namespace DbC.Net.Tests.Unit.TestData;

public class PointRecordData : ComparableValue<PointRecord>
{
   public PointRecordData() : base(
      new PointRecord(1, 1),
      new PointRecord(-1, -1),
      new ReverseComparer<PointRecord>(),
      new PointRecord(0, 0),
      new PointRecord(10, 10))
   { }
}