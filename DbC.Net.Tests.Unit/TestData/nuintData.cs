namespace DbC.Net.Tests.Unit.TestData;

#pragma warning disable IDE1006 // Naming Styles
public class nuintData : ComparableValue<nuint>
#pragma warning restore IDE1006 // Naming Styles
{
   public nuintData() : base(
      100,
      101,
      Comparer<nuint>.Default,
      new ReverseComparer<nuint>(),
      nuint.MinValue,
      nuint.MaxValue,
      nuint.MaxValue / 4,
      nuint.MaxValue / 4 * 3,
      nuint.MinValue,
      nuint.MaxValue / 2,
      nuint.MaxValue)
   { }
}
