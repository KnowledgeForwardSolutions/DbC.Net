namespace DbC.Net.Tests.Unit.TestData;

public class TimeSpanData : ComparableValue<TimeSpan>
{
   public TimeSpanData() : base(
      new(4096),
      new(2048),
      Comparer<TimeSpan>.Default,
      new ReverseComparer<TimeSpan>(),
      TimeSpan.MinValue,
      TimeSpan.MaxValue,
      new(2048),
      new(4096),
      TimeSpan.MinValue,
      new(3064),
      TimeSpan.MaxValue)
   { }
}
