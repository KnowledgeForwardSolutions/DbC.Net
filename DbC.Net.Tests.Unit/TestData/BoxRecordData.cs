namespace DbC.Net.Tests.Unit.TestData;

public class BoxRecordData : ComparableValue<Box>
{
   public BoxRecordData() : base(
      new Box(1, 2, 3, "Blue"),
      new Box(2, 2, 2, "Red"),
      BoxComparers.AllFieldsComparer,
      new ReverseComparer<Box>(),
      new Box(1, 1, 1, "Green"),
      new Box(100, 100, 100, "Blue"),
      new Box(3, 3, 3, "Orange"),
      new Box(9, 9, 9, "Yellow"),
      new Box(1, 1, 1, "Green"),
      new Box(5, 5, 5, "Red"),
      new Box(100, 100, 100, "Blue"))
   { }
}
