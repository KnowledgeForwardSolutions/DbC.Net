namespace DbC.Net.Tests.Unit.TestData;

public class DateTimeOffsetData : ComparableValue<DateTimeOffset>
{
   public DateTimeOffsetData() : base(
      new DateTimeOffset(new DateTime(DateTimeOffset.MaxValue.Ticks / 4)),
      new DateTimeOffset(new DateTime(DateTimeOffset.MaxValue.Ticks / 2)),
      new ReverseComparer<DateTimeOffset>(),
      DateTimeOffset.MinValue,
      DateTimeOffset.MaxValue,
      new(new DateTime(1966, 9, 8, 18, 30, 0)),  // TOS first episode aired
      new(new DateTime(1969, 6, 3, 20, 0, 0)),  // TOS last episode aired
      new(new DateTime(1965, 9, 15, 17, 30, 0)), // Lost in Space first episode aired
      new(new DateTime(1967, 9, 15, 18, 30, 0)), // TOS Amok Time first aired
      new(new DateTime(1979, 4, 29, 18, 0, 0))) // Battlestar Galactica last episode aired
   { }
}