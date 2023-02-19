namespace DbC.Net.Tests.Unit.TestData;

public class DateTimeData : ComparableValue<DateTime>
{
   public DateTimeData() : base(
      new(2000, 1, 1),
      new(1970, 1, 1),
      new ReverseComparer<DateTime>(),
      DateTime.MinValue,
      DateTime.MaxValue)
   { }
}
