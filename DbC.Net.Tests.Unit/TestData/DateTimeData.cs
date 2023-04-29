namespace DbC.Net.Tests.Unit.TestData;

public class DateTimeData : ComparableValue<DateTime>
{
   public DateTimeData() : base(
      new(2000, 1, 1),
      new(1970, 1, 1),
      Comparer<DateTime>.Default,
      new ReverseComparer<DateTime>(),
      DateTime.MinValue,
      DateTime.MaxValue,
      new(1966, 9, 8, 18, 30, 0),  // TOS first episode aired
      new(1969, 6, 3, 20, 0, 0),  // TOS last episode aired
      new(1965, 9, 15, 17, 30, 0), // Lost in Space first episode aired
      new(1967, 9, 15, 18, 30, 0), // TOS Amok Time first aired
      new(1979, 4, 29, 18, 0, 0)) // Battlestar Galactica last episode aired
   { }
}
