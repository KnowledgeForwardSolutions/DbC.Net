namespace DbC.Net.Tests.Unit.TestData;

public class DateTimeOffsetData : ComparableValue<DateTimeOffset>
{
   public DateTimeOffsetData() : base(
      new DateTimeOffset(new DateTime(DateTimeOffset.MaxValue.Ticks / 4)),
      new DateTimeOffset(new DateTime(DateTimeOffset.MaxValue.Ticks / 2)),
      new ReverseComparer<DateTimeOffset>(),
      DateTimeOffset.MinValue,
      DateTimeOffset.MaxValue)
   { }
}