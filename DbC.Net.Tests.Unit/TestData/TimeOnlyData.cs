namespace DbC.Net.Tests.Unit.TestData;

public class TimeOnlyData : ComparableValue<TimeOnly>
{
   public TimeOnlyData() : base(
      new(12, 1, 1),
      new(20, 1, 1),
      new ReverseComparer<TimeOnly>(),
      TimeOnly.MinValue,
      TimeOnly.MaxValue,
      new(4, 0, 0),
      new(20, 0, 0),
      TimeOnly.MinValue,
      new(12, 0, 0),
      TimeOnly.MaxValue)
   { }
}
