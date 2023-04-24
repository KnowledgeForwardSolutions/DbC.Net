namespace DbC.Net.Tests.Unit.TestData;

public class PointStructData : ComparableValue<Point>
{
   public PointStructData() : base(
      new Point { X = 1, Y = 1 },
      new Point { X = -1, Y = -1 },
      new ReverseComparer<Point>(),
      new Point { X = 0, Y = 0 },
      new Point { X = 10, Y = 10 },
      new Point { X = 3, Y = 3 },
      new Point { X = 7, Y = 7 },
      new Point { X = 0, Y = 0 },
      new Point { X = 5, Y = 5 },
      new Point { X = 9, Y = 9 })
   { }
}