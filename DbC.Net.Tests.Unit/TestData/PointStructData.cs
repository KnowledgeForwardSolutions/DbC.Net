namespace DbC.Net.Tests.Unit.TestData;

public class PointStructData : ComparableValue<Point>
{
   public PointStructData() : base(
      new Point { X = 1, Y = 1 },
      new Point { X = -1, Y = -1 },
      new ReverseComparer<Point>(),
      new Point { X = 0, Y = 0 },
      new Point { X = 10, Y = 10 })
   { }
}