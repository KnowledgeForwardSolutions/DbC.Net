namespace DbC.Net.Tests.Unit.TestData;

public class TimeOnlyData : ComparableValue<TimeOnly>
{
   public TimeOnlyData() : base(
      new(12, 1, 1),
      new(20, 1, 1),
      new ReverseComparer<TimeOnly>(),
      TimeOnly.MinValue,
      TimeOnly.MaxValue)
   { }
}
