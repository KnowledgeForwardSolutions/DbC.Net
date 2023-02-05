namespace DbC.Net.Tests.Unit.TestData;

public class CharData : ComparableValue<Char>
{
   public CharData() : base(
      'A',
      'z',
      new ReverseComparer<Char>(),
      Char.MinValue,
      Char.MaxValue)
   { }
}
