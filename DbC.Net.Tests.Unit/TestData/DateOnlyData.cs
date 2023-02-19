namespace DbC.Net.Tests.Unit.TestData;

public class DateOnlyData : ComparableValue<DateOnly>
{
   public DateOnlyData() : base(
      new(2000, 1, 1),
      new(1970, 1, 1),
      new ReverseComparer<DateOnly>(),
      DateOnly.MinValue,
      DateOnly.MaxValue)
   { }
}
