namespace DbC.Net.Tests.Unit.TestData;

public class BoxRecordData : ComparableValue<Box>
{
   public BoxRecordData() : base(
      new Box(1, 2, 3, "Blue"),
      new Box(2, 2, 2, "Red"),
      new ReverseComparer<Box>(),
      new Box(1, 1, 1, "Green"),
      new Box(100, 100, 100, "Blue"))
   { }
}
