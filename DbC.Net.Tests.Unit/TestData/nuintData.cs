namespace DbC.Net.Tests.Unit.TestData;

#pragma warning disable IDE1006 // Naming Styles
public class nuintData : ComparableValue<nuint>
#pragma warning restore IDE1006 // Naming Styles
{
   public nuintData() : base(
      100,
      101,
      new ReverseComparer<nuint>(),
      nuint.MinValue,
      nuint.MaxValue)
   { }
}
