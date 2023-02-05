namespace DbC.Net.Tests.Unit.TestData;

public class PointStructData : ComparableValue<PointStruct>
{
   public PointStructData() : base(
      new PointStruct { X = 1, Y = 1 },
      new PointStruct { X = -1, Y = -1 },
      new ReverseComparer<PointStruct>(),
      new PointStruct { X = 0, Y = 0 },
      new PointStruct { X = 10, Y = 10 })
   { }
}