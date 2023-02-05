namespace DbC.Net.Tests.Unit.TestData;

public class PointClassData : ComparableValue<PointClass>
{
   public PointClassData() : base(
      new PointClass { X = 1, Y = 1 },
      new PointClass { X = -1, Y = -1 },
      new ReverseComparer<PointClass>(),
      new PointClass { X = 0, Y = 0 },
      new PointClass { X = 10, Y = 10 })
   { }
}