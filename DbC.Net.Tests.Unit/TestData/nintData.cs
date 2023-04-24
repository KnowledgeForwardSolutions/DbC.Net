namespace DbC.Net.Tests.Unit.TestData;

#pragma warning disable IDE1006 // Naming Styles
public class nintData : ComparableValue<nint>
#pragma warning restore IDE1006 // Naming Styles
{
   public nintData() : base(
      100,
      101,
      new ReverseComparer<nint>(),
      nint.MinValue,
      nint.MaxValue,
      nint.MinValue / 2,
      nint.MaxValue / 2,
      nint.MinValue,
      0,
      nint.MaxValue)
   { }
}