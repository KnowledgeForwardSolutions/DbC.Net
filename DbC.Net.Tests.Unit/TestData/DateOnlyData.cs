namespace DbC.Net.Tests.Unit.TestData;

public class DateOnlyData : ComparableValue<DateOnly>
{
   public DateOnlyData() : base(
      new(2000, 1, 1),
      new(1970, 1, 1),
      new ReverseComparer<DateOnly>(),
      DateOnly.MinValue,
      DateOnly.MaxValue,
      new(1966, 9, 8),  // TOS first episode aired
      new(1969, 6, 3),  // TOS last episode aired
      new(1965, 9, 15), // Lost in Space first episode aired
      new(1967, 9, 15), // TOS Amok Time first aired
      new(1979, 4, 29)) // Battlestar Galactica last episode aired
   { }
}
